using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SecondFloor.Model.UnitTest.Anuncio_Tests
{
    public class When_Registering_Anuncio
    {
        private Anuncio anuncio;

        [SetUp]
        public void Init()
        {
            anuncio = new Anuncio();
            anuncio.Titulo = "Ofertas Relampago";
            anuncio.DataInicio = DateTime.Now;
            anuncio.DataFim = DateTime.Now.AddDays(7);
            anuncio.Ofertas = new List<Oferta>()
            {
                new Oferta()
            };
            anuncio.Anunciante = new Anunciante();
        }

        [Test]
        public void test_anuncio_with_datainicio_before_dataatual()
        {
            var esperado = 0;
            anuncio.DataInicio = DateTime.Now.AddDays(-1); //ontem

            //data anuncio é ANTERIOR data de publicacao
            var dataPublicacao = anuncio.DataInicio;
            var dataAtual = DateTime.Now;
            var comparacao = dataAtual.Date.CompareTo(dataPublicacao.Date);

            Assert.GreaterOrEqual(comparacao, esperado,
                "Data de inicio do anuncio deve ser maior que a data de publicacao");
            //Assert.True(anuncio.GetBrokenBusinessRules().Count > esperado);
        }

        [Test]
        public void test_anuncio_with_datainicio_with_same_dataatual()
        {
            var esperado = 0;
            anuncio.DataInicio = DateTime.Now.AddDays(0); //hj

            //data anuncio é IGUAL data de publicacao
            var dataPublicacao = anuncio.DataInicio;
            var dataAtual = DateTime.Now;
            var comparacao = dataAtual.Date.CompareTo(dataPublicacao.Date);

            Assert.GreaterOrEqual(comparacao, esperado,
                "Data de fim do anuncio deve ser maior que a data de publicacao");
            //Assert.True(anuncio.GetBrokenBusinessRules().Count > esperado);
        }

        [Test]
        public void test_anuncio_with_datainicio_after_dataatual()
        {
            var esperado = 0;
            anuncio.DataInicio = DateTime.Now.AddDays(1);  //amanha

            //data anuncio é POSTERIOR data de publicacao
            var dataPublicacao = anuncio.DataInicio;
            var dataAtual = DateTime.Now;
            var comparacao = dataAtual.Date.CompareTo(dataPublicacao.Date);

            Assert.Less(comparacao, esperado);
        }

        [Test]
        public void test_anuncio_with_datafinal_equal_datainicio()
        {
            anuncio.DataInicio = DateTime.Now.AddDays(3); //igual
            anuncio.DataFim = DateTime.Now.AddDays(3); //igual

            var inicio = anuncio.DataFim.Date;
            var fim = anuncio.DataInicio.Date;

            Assert.True(inicio.CompareTo(fim) == 0);
        }

        [Test]
        public void test_anuncio_with_datafinal_before_datainicio()
        {
            anuncio.DataInicio = DateTime.Now.AddDays(3); //inicio posterior ao fim
            anuncio.DataFim = DateTime.Now.AddDays(2); //fim inferior ao inicio

            var inicio = anuncio.DataInicio.Date;
            var fim = anuncio.DataFim.Date;

            Assert.True(inicio.CompareTo(fim) > 0);
        }

        [Test]
        public void test_anuncio_must_have_at_least_one_oferta()
        {
            anuncio.Ofertas = new List<Oferta>();

            Assert.True(anuncio.Ofertas.Count() == 0,"Anuncio sem ofertas deve retornar um erro");
        }
    }
}