using System;
using System.Diagnostics;
using NUnit.Framework;
using SecondFloor.DataContracts.Messages;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;
using SecondFloor.Model.Specifications;
using SecondFloor.RepositoryEF;
using SecondFloor.RepositoryEF.Repositories;
using SecondFloor.Service.ExtensionMethods;

namespace SecondFloor.Service.IntegratedTest.AnuncianteService_Tests
{
    [TestFixture]
    public class When_Registering_Anunciante
    {
        private AnuncioRepository _anuncioRepository;
        private AnuncianteRepository _anuncianteRepository;
        private IUnitOfWork _unitOfworkAnuncio;
        private IUnitOfWork _unitOfworkAnunciante;
        

        [SetUp]
        public void Init()
        {
            _unitOfworkAnuncio = new EFUnitOfWork<Anuncio>();
            _anuncioRepository = new AnuncioRepository(_unitOfworkAnuncio);

            _unitOfworkAnunciante = new EFUnitOfWork<Anunciante>();
            _anuncianteRepository = new AnuncianteRepository(_unitOfworkAnunciante);
        }

        [TearDown]
        public void Finish()
        {
            //_anuncianteRepository.Dispose();
            //_anuncioRepository.Dispose();
            //_commonContext.Dispose();
        }

        [Test]
        public void test_if_anunciante_was_invalid_fail()
        {
            //Arrange
            var anunciante = GerarAnunciante();
            anunciante.Token = "0000000000";

            var request = new CadastroAnuncianteRequest();
            request.Anunciante = anunciante.ConvertToAnuncianteDto();
            request.Anunciante.Anuncios = null;

            //Act
            var anuncioService = new AnuncianteService(_anuncioRepository, _anuncianteRepository);
            var response = anuncioService.CadastrarAnunciante(request);

            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsFalse(response.Success);
        }

        [Test]
        public void test_if_anunciante_was_inserted_pass()
        {
            //Arrange
            var anunciante = GerarAnunciante();

            var request = new CadastroAnuncianteRequest();
            request.Anunciante = anunciante.ConvertToAnuncianteDto();
            request.Anunciante.Anuncios = null;

            //Act
            var anuncioService = new AnuncianteService(_anuncioRepository, _anuncianteRepository);
            var response = anuncioService.CadastrarAnunciante(request);

            //Assert
            Debug.WriteLine(response.Message);
            Assert.IsTrue(response.Success);

            //remover do banco
            _anuncianteRepository.ExcluirAnunciante(anunciante.Id);
            _anuncianteRepository.Persist();
        }

        private static Anunciante GerarAnunciante()
        {
            var anunciante = new Anunciante
            {
                Id = Guid.NewGuid(),
                RazaoSocial = "Oficina de entretenimento adulto do tio careca",
                Cnpj = "40.123.456/0001-63",
                Responsavel = "Fulano de Tal",
                Email = "careca@careca.com.br",
            };
            anunciante.Token = anunciante.GetToken();

            return anunciante;
        }
    }
}