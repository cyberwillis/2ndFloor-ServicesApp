using System;
using System.Diagnostics;
using NUnit.Framework;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages;
using SecondFloor.Infrastructure;
using SecondFloor.Model;
using SecondFloor.RepositoryEF;
using SecondFloor.Service.ExtensionMethods;

namespace SecondFloor.Service.IntegratedTest.AnuncioService_Tests
{
    [TestFixture]
    public class When_Publishing_Anuncio
    {
        private AnuncioDto _anuncioDto;
        private AnuncioContext _commonContext;
        private AnuncianteRepository _anuncianteRepository;
        private AnuncioRepository _anuncioRepository;
        private string _anuncianteToken;

        [SetUp]
        public void Init()
        {
            _commonContext = new AnuncioContext();
            _anuncioRepository = new AnuncioRepository(_commonContext);
            _anuncianteRepository = new AnuncianteRepository(_commonContext);
        }
        
        [TearDown]
        public void Finish()
        {
            var anunciante = _anuncianteRepository.EncontrarAnunciantePorToken(_anuncianteToken);
            if (anunciante != null)
            {
                _anuncianteRepository.ExcluirAnunciante(anunciante.Id);
                _anuncianteRepository.Persist();
            }

            _anuncianteRepository.Dispose();
            _anuncioRepository.Dispose();
            _commonContext.Dispose();
        }

        [Test]
        public void test_if_anuncio_was_inserted_pass()
        {
            //Arrange
            var anunciante = GerarAnunciante(); //Anunciante
            _anuncianteToken = anunciante.Token;
            _anuncianteRepository.InserirAnunciante(anunciante);
            _anuncianteRepository.Persist();

            var anuncio = GerarAnuncio(anunciante); //Anuncio
            _anuncioDto = anuncio.ConvertToAnuncioDto(); //Cascade DTO Convertion
            
            var request = new CadastrarAnuncioRequest { Anuncio = _anuncioDto, AnuncianteToken = anunciante.Token };

            //Act
            var anuncioService = new AnuncioService(_anuncioRepository, _anuncianteRepository);
            var response = anuncioService.CadastrarAnuncio(request);
         
            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsTrue(response.Success);
        }

        [Test]
        public void test_if_anuncio_was_invalid_fail()
        {
            //Arrange
            var anunciante = GerarAnunciante(); //Anunciante not exists in database

            var anuncio = GerarAnuncio(anunciante); //Anuncio
            _anuncioDto = anuncio.ConvertToAnuncioDto(); //Cascade DTO Convertion

            var request = new CadastrarAnuncioRequest { Anuncio = _anuncioDto, AnuncianteToken = anunciante.Token };

            //Act
            var anuncioService = new AnuncioService(_anuncioRepository, _anuncianteRepository);
            var response = anuncioService.CadastrarAnuncio(request);

            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsFalse(response.Success);
        }

        #region Helpers

        private static Anuncio GerarAnuncio(Anunciante anunciante)
        {
            //Endereco
            var endereco = new Endereco
            {
                Id = new Guid(),
                Logradouro = "Rua ABC",
                Numero = "1",
                Bairro = "Cidade Dultra",
                Cidade = "Sao Paulo",
                Estado = "SP"
            };

            //Oferta
            var oferta = new Oferta
            {
                Id = new Guid(),
                Titulo = "Servico 1",
                Descricao = "Fazemos qualquer negocia!",
                Preco = "100.00"
            };
            oferta.Endereco = endereco;

            //Anuncio
            var anuncio = new Anuncio
            {
                Id = new Guid(),
                Titulo = "Anuncio Teste",
                DataInicio = DateTime.Now.AddDays(1),
                DataFim = DateTime.Now.AddDays(7),
            };
            anuncio.Anunciante = anunciante;
            anuncio.Ofertas.Add(oferta);
            return anuncio;
        }
        private static Anunciante GerarAnunciante()
        {
            var anunciante = new Anunciante
            {
                Id = new Guid(),
                RazaoSocial = "Oficina de entretenimento adulto do tio careca",
                Cnpj = "40.123.456.0001-10"
            };
            anunciante.Token = Sha1Util.SHA1HashStringForUTF8String(anunciante.RazaoSocial + anunciante.Cnpj);
            return anunciante;
        }

        #endregion
    }
}