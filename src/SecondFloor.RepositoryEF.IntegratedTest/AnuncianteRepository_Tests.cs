using System;
using NUnit.Framework;
using SecondFloor.Infrastructure;
using SecondFloor.Model;
using SecondFloor.Model.Specifications;

namespace SecondFloor.RepositoryEF.IntegratedTest.AnuncioRepository_Test
{
    public class AnuncianteRepository_Tests
    {
        private AnuncioContext _commonContext;
        private AnuncianteRepository _anuncianteRepository;
        private Anunciante _anunciante;
        

        [SetUp]
        public void Init()
        {
             _commonContext = new AnuncioContext();
            _anuncianteRepository = new AnuncianteRepository(_commonContext); //contexto compartilhado
        }

        [TearDown]
        public void Finish()
        {
            _anuncianteRepository.Dispose();
            _commonContext.Dispose();
        }

        [Test]
        public void test_EncontrarAnunciantesPor_returns_one_element_pass()
        {
            //Anunciante
            _anunciante = new Anunciante();
            _anunciante.Id = Guid.NewGuid(); //Guid de Teste
            _anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            _anunciante.Cnpj = "40.123.456.0001-63";
            _anunciante.Token = _anunciante.GetToken();

            _anuncianteRepository.InserirAnunciante(_anunciante);
            _anuncianteRepository.Persist();

            var anunciante = _anuncianteRepository.EncontrarAnunciantePor(_anunciante.Id);

            Assert.IsTrue(anunciante != null);

            _anuncianteRepository.ExcluirAnunciante(_anunciante.Id);
            _anuncianteRepository.Persist();

        }

        [Test]
        public void test_EncontrarAnunciantesPorToken_returns_one_element_pass()
        {
            //Anunciante
            _anunciante = new Anunciante();
            _anunciante.Id = Guid.NewGuid(); //Guid de Teste
            _anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            _anunciante.Cnpj = "40.123.456.0001-63";
            _anunciante.Token = _anunciante.GetToken();

            var token = _anunciante.GetToken();

            _anuncianteRepository.InserirAnunciante(_anunciante);
            _anuncianteRepository.Persist();

            var anunciante = _anuncianteRepository.EncontrarAnunciantePorToken(token);

            Assert.IsTrue(anunciante != null);

            _anuncianteRepository.ExcluirAnunciante(_anunciante.Id);
            _anuncianteRepository.Persist();
        }

        [Test]
        public void test_ExcluirAnunciante_returns_zero_elements_pass()
        {
            //Anunciante
            _anunciante = new Anunciante();
            _anunciante.Id = Guid.NewGuid(); //Guid de Teste
            _anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            _anunciante.Cnpj = "40.123.456.0001-63";
            _anunciante.Token = _anunciante.GetToken();

            _anuncianteRepository.InserirAnunciante(_anunciante);
            _anuncianteRepository.Persist();

            var anuncianteId = _anunciante.Id;

            var anunciante = _anuncianteRepository.EncontrarAnunciantePor(anuncianteId);

            Assert.IsTrue(anunciante != null);

            _anuncianteRepository.ExcluirAnunciante(_anunciante.Id);
            _anuncianteRepository.Persist();

            anunciante = _anuncianteRepository.EncontrarAnunciantePor(anuncianteId);

            Assert.IsNull(anunciante);
        }

    }
}