using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using NUnit.Framework;
using Rhino.Mocks;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages;
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
        public void test_if_anuncio_is_saved_when_anuncio_is_vallid()
        {
            //Arrange
            var mockAnuncioRepository = MockRepository.GenerateMock<IAnuncioRepository<Anuncio, Guid>>();
            mockAnuncioRepository.Stub(x => x.Insert(Arg<Anuncio>.Is.Anything));
            mockAnuncioRepository.Stub(x => x.Persist());
            
            var mockAnuncianteRepository = MockRepository.GenerateMock<IAnuncianteRepository<Anunciante, Guid>>();
            mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePorToken(Arg<string>.Is.Anything)).Return(new Anunciante());

            var anuncioService = new AnuncioService(mockAnuncioRepository, mockAnuncianteRepository);
            var cadastrarAnuncioRequest = new CadastrarAnuncioRequest() { Anuncio = _anuncioDto };

            //Act
            anuncioService.CadastrarAnuncio(cadastrarAnuncioRequest);
            
            //Assert
            mockAnuncioRepository.AssertWasCalled(x=>x.Persist());
        }

        [Test]
        public void test_if_anunciante_is_unknown()
        {
            //Arrange
            var mockAnuncioRepository = MockRepository.GenerateMock<IAnuncioRepository<Anuncio, Guid>>();
            var mockAnuncianteRepository = MockRepository.GenerateMock<IAnuncianteRepository<Anunciante, Guid>>();
            mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePorToken(Arg<string>.Is.Anything)).Return(null); //anunciante é nulo

            var anuncioService = new AnuncioService(mockAnuncioRepository, mockAnuncianteRepository);
            var cadastrarAnuncioRequest = new CadastrarAnuncioRequest() { Anuncio = _anuncioDto };

            //Act
            var response = anuncioService.CadastrarAnuncio(cadastrarAnuncioRequest);

            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsFalse(response.Success);
        }

        [Test]
        public void test_if_anuncio_contains_errors()
        {
            //Arrange
            var mockAnuncioRepository = MockRepository.GenerateMock<IAnuncioRepository<Anuncio, Guid>>();
            var mockAnuncianteRepository = MockRepository.GenerateMock<IAnuncianteRepository<Anunciante, Guid>>();
            mockAnuncianteRepository.Stub(x => x.EncontrarAnunciantePorToken(Arg<string>.Is.Anything)).Return(new Anunciante());
            
            var anuncioService = new AnuncioService(mockAnuncioRepository, mockAnuncianteRepository);
            var cadastrarAnuncioRequest = new CadastrarAnuncioRequest() { Anuncio = new AnuncioDto() }; 

            //Act
            var response = anuncioService.CadastrarAnuncio(cadastrarAnuncioRequest);

            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsFalse(response.Success);
        }
    }
}