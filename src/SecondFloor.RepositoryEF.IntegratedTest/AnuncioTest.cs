using System;
using System.Collections.Generic;
using NUnit.Framework;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.IntegratedTest
{
    [TestFixture]
    public class AnuncioTest
    {
        private AnuncioRepository _anuncioRepository;

        [SetUp]
        public void Init()
        {
            _anuncioRepository = new AnuncioRepository(new AnuncioContext());
        }

        [Test]
        public void test_EncontrarTodosAnuncios_returns_one_or_zero_elements()
        {
            var anuncios = _anuncioRepository.EncontrarTodosAnuncios();

            Assert.GreaterOrEqual(anuncios.Count, 0);
        }

        [Test]
        public void test_InserirAnuncio()
        {
            /*var anunciante = new Anunciante
            {
                Id = Guid.NewGuid(),
                Token = "1234567890",
                Cnpj = "0000000000",
                RazaoSocial = "Teste razao social"
            };

            var anuncio = new Anuncio()
            {
                Id = Guid.NewGuid(),
                Titulo = "Anuncio Teste",
                DataInicio = DateTime.Now.AddDays(1),
                DataFim = DateTime.Now.AddDays(7),
            };
            anunciante.Anuncios.Add(anuncio);
            anuncio.Anunciante = anunciante;*/

            /*var oferta = new Oferta()
            {
                Id = Guid.NewGuid(),
                Titulo = "Servico 1",
                Descricao = "Fazemos qualquer negocia!",
                Preco = "100.00",
            };
            var endereco = new Endereco()
            {
                Id = Guid.NewGuid(),
                Logradouro = "Rua ABC",
                Numero = "1",
                Bairro = "Cidade Dultra",
                Cidade = "Sao Paulo",
                Estado = "SP"
            };*/

            //oferta.Endereco = endereco;
            
            //var ofertas = new List<Oferta>();
            //ofertas.Add(oferta);

            _anuncioRepository.InserirAnuncio(anuncio);
            _anuncioRepository.Persist();
        }
    }
}