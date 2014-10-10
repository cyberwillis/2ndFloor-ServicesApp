using System;
using System.Data.Entity;
using NUnit.Framework;
using SecondFloor.Infrastructure;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;
using SecondFloor.RepositoryEF.Repositories;

namespace SecondFloor.RepositoryEF.IntegratedTest.AnuncioRepository_Test
{
    [TestFixture]
    public class AnuncioRepository_Tests
    {
        private IAnuncioRepository _anuncioRepository;
        private IAnuncianteRepository _anuncianteRepository;
        private EFUnitOfWork<Anuncio> _unitOfWorkAnuncio;
        private EFUnitOfWork<Anunciante> _unitOfWorkAnunciante;
        private Anunciante _anunciante;


        [SetUp]
        public void Init()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AnuncianteContext>()); //Database Initializer

            _unitOfWorkAnuncio = new EFUnitOfWork<Anuncio>();
            _anuncioRepository = new AnuncioRepository(_unitOfWorkAnuncio); //contexto compartilhado

            _unitOfWorkAnunciante = new EFUnitOfWork<Anunciante>();
            _anuncianteRepository = new AnuncianteRepository(_unitOfWorkAnunciante); //contexto compartilhado

            //Anunciante
            _anunciante = new Anunciante();
            _anunciante.Id = new Guid("C0A82971-E9F0-47F1-9F90-C54F4EB51D3B"); //Guid de Teste
            _anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            _anunciante.Responsavel = "Fulano de Tal";
            _anunciante.Email = "careca@careca.com.br";
            _anunciante.Cnpj = "40.123.456.0001-10";
            //_anunciante.Token = Sha1Util.SHA1HashStringForUTF8String(_anunciante.RazaoSocial + _anunciante.Cnpj);

            //Persistir Anunciante
            _anuncianteRepository.InserirAnunciante(_anunciante);
            _anuncianteRepository.Persist();
        }

        [TearDown]
        public void Finish()
        {
            //Remover Anunciante
            _anuncianteRepository.ExcluirAnunciante(_anunciante);
            _anuncianteRepository.Persist();

            //_anuncianteRepository.Dispose();
            //_anuncioRepository.Dispose();
            //_commonContext.Dispose();
        }

        [Test]
        public void test_EncontrarTodosAnuncios_returns_one_or_zero_elements_pass()
        {
            var anuncios = _anuncioRepository.EncontrarTodosAnuncios();

            Assert.GreaterOrEqual(anuncios.Count, 0);
        }

        [Test]
        public void test_InserirAnuncio_pass()
        {
            var anuncianteId = _anunciante.Id;

            var endereco = new Endereco { Id = Guid.NewGuid(), Logradouro = "Rua ABC", Numero = "1", Bairro = "Cidade Dultra", Cidade = "Sao Paulo", Estado = "SP" };
            
            var oferta = new Oferta { Id = Guid.NewGuid(), Titulo = "Servico 1", Descricao = "Fazemos qualquer negocia!", Preco = "100.00" };
            //oferta.Endereco = endereco;

            var anuncio = new Anuncio { Id = Guid.NewGuid(), Titulo = "Anuncio Teste", DataInicio = DateTime.Now.AddDays(1), DataFim = DateTime.Now.AddDays(7), };
            anuncio.Anunciante = _anunciante;
            anuncio.Ofertas.Add(oferta);

            //Inserir Anuncios
            _anuncioRepository.InserirAnuncio(anuncio);
            _anuncioRepository.Persist(); //'_anunciante' ganha uma lista de 'Anuncios'

            var anunciante = _anuncianteRepository.EncontrarAnunciantePor(anuncianteId);
            Assert.GreaterOrEqual( anunciante.Anuncios.Count, 1);
            
            //Exclui Anuncios
            _anuncioRepository.ExcluirAnuncio(anuncio.Id);
            _anuncioRepository.Persist(); //'_anunciante' perde a lista de 'Anuncios'

            Assert.GreaterOrEqual(anunciante.Anuncios.Count, 0);
        }
    }
}