using System;
using System.Collections.Generic;
using System.Diagnostics;
using NUnit.Framework;
using Rhino.Mocks;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages;
using SecondFloor.DataContracts.Messages.Anunciante;
using SecondFloor.Model;
using SecondFloor.Service.ExtensionMethods;

namespace SecondFloor.Service.UnitTest.Anuncio_Tests
{
    [TestFixture]
    public class When_Publishing_Anuncio
    {
        private AnuncioDto _anuncioDto;

        [SetUp]
        public void Init()
        {
            var anuncio = new Anuncio()
            {
                Id = new Guid(),
                Titulo = "Anuncio Teste",
                DataInicio = DateTime.Now.AddDays(1),
                DataFim = DateTime.Now.AddDays(7),
                Ofertas = new List<Oferta>()
                {
                    new Oferta()
                    {
                        Titulo = "Servico 1",
                        Descricao = "Fazemos qualquer negocia!",
                        Preco = "100.00",
                        Endereco = new Endereco()
                        {
                            Logradouro = "Rua ABC",
                            Numero = "1",
                            Bairro = "Cidade Dultra",
                            Cidade = "Sao Paulo",
                            Estado = "SP"
                        }
                    }
                },
                Anunciante = null,
            };

            _anuncioDto = anuncio.ConvertToAnuncioDto(); //cascata de ExtensionMethods
        }


        [Test]
        public void test_if_anuncio_was_valid_pass()
        {
            //Arrange
            var mockAnuncioRepository = MockRepository.GenerateMock<IAnuncioRepository>();
            mockAnuncioRepository.Stub(x => x.InserirAnuncio(Arg<Anuncio>.Is.Anything));
            mockAnuncioRepository.Stub(x => x.Persist());
            
            var mockAnuncianteRepository = MockRepository.GenerateMock<IAnuncianteRepository>();
            mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePor(Arg<Guid>.Is.Anything)).Return(new Anunciante());
            //mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePorToken(Arg<string>.Is.Anything)).Return(new Anunciante());

            var anuncioService = new AnuncianteService(mockAnuncioRepository, mockAnuncianteRepository);
            var cadastrarAnuncioRequest = new CadastrarAnuncioRequest() { Anuncio = _anuncioDto };

            //Act
            anuncioService.CadastrarAnuncio(cadastrarAnuncioRequest);
            
            //Assert
            mockAnuncioRepository.AssertWasCalled(x=>x.Persist());
        }

        [Test]
        public void test_if_anunciante_was_unknown_fail()
        {
            //Arrange
            var mockAnuncioRepository = MockRepository.GenerateMock<IAnuncioRepository>();
            var mockAnuncianteRepository = MockRepository.GenerateMock<IAnuncianteRepository>();
            mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePor(Arg<Guid>.Is.Anything)).Return(null); //anunciante é nulo
            //mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePorToken(Arg<string>.Is.Anything)).Return(null); //anunciante é nulo

            var anuncioService = new AnuncianteService(mockAnuncioRepository, mockAnuncianteRepository);
            var cadastrarAnuncioRequest = new CadastrarAnuncioRequest() { Anuncio = _anuncioDto };

            //Act
            var response = anuncioService.CadastrarAnuncio(cadastrarAnuncioRequest);

            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsFalse(response.Success);
        }

        [Test]
        public void test_if_anuncio_has_errors_fail()
        {
            //Arrange
            var mockAnuncioRepository = MockRepository.GenerateMock<IAnuncioRepository>();
            var mockAnuncianteRepository = MockRepository.GenerateMock<IAnuncianteRepository>();
            mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePor(Arg<Guid>.Is.Anything)).Return(new Anunciante());
            //mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePorToken(Arg<string>.Is.Anything)).Return(new Anunciante());
            
            var anuncioService = new AnuncianteService(mockAnuncioRepository, mockAnuncianteRepository);
            var cadastrarAnuncioRequest = new CadastrarAnuncioRequest() { Anuncio = new AnuncioDto() }; 

            //Act
            var response = anuncioService.CadastrarAnuncio(cadastrarAnuncioRequest);

            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsFalse(response.Success);
        }
    }
}