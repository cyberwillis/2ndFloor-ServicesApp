using System;
using System.Data.Entity;
using NUnit.Framework;
using SecondFloor.Model;
using SecondFloor.RepositoryEF.Repositories;

namespace SecondFloor.RepositoryEF.IntegratedTest.AnuncioRepository_Test
{
    public class AnuncianteRepository_Tests
    {
        private AnuncianteRepository _anuncianteRepository;
        private Anunciante _anunciante;
        private EFUnitOfWork<Anunciante> _unitOfworkAnunciante;


        [SetUp]
        public void Init()
        {
            Database.SetInitializer(new DropCreateDatabaseAlways<AnuncianteContext>()); //Database Initializer

            _unitOfworkAnunciante = new EFUnitOfWork<Anunciante>();
            _anuncianteRepository = new AnuncianteRepository(_unitOfworkAnunciante); //contexto compartilhado
        }

        [TearDown]
        public void Finish()
        {
            //Dispose if needed
        }

        [Test]
        public void test_EncontrarAnunciantesPor_returns_one_element_pass()
        {
            var id = Guid.NewGuid(); //Guid de Teste;

            //Anunciante
            _anunciante = new Anunciante();
            _anunciante.Id = id;
            _anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            _anunciante.Responsavel = "Fulano de Tal";
            _anunciante.Email = "careca@careca.com.br";
            _anunciante.Cnpj = "40.123.456.0001-63";
            //_anunciante.Token = _anunciante.GetToken();

            _anuncianteRepository.InserirAnunciante(_anunciante);
            _anuncianteRepository.Persist();

            var anunciante = _anuncianteRepository.EncontrarAnunciantePor(id);

            Assert.IsTrue(anunciante != null);

            _anuncianteRepository.ExcluirAnunciante(_anunciante);
            _anuncianteRepository.Persist();
        }

        [Test]
        public void test_ExcluirAnunciante_returns_zero_elements_pass()
        {
            //Anunciante
            _anunciante = new Anunciante();
            _anunciante.Id = Guid.NewGuid(); //Guid de Teste
            _anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            _anunciante.Responsavel = "Fulano de Tal";
            _anunciante.Email = "careca@careca.com.br";
            _anunciante.Cnpj = "40.123.456.0001-63";
            //_anunciante.Token = _anunciante.GetToken();

            _anuncianteRepository.InserirAnunciante(_anunciante);
            _anuncianteRepository.Persist();

            var anuncianteId = _anunciante.Id;

            var anunciante = _anuncianteRepository.EncontrarAnunciantePor(anuncianteId);

            Assert.IsTrue(anunciante != null);

            _anuncianteRepository.ExcluirAnunciante(_anunciante);
            _anuncianteRepository.Persist();

            anunciante = null;
            anunciante = _anuncianteRepository.EncontrarAnunciantePor(anuncianteId);

            Assert.IsNull(anunciante);
        }

    }
}