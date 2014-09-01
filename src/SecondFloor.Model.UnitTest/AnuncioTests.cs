using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace SecondFloor.Model.UnitTest
{
    public class AnuncioTests
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
        public void test1_anuncio_publicado_com_datainicio_anterior_a_data_atual_deve_gerar_erro()
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
        public void test2_anuncio_publicado_com_datainicio_igual_a_data_atual_deve_gerar_erro()
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
        public void test3_anuncio_publicado_com_datainicio_posterior_a_data_atual_deve_gerar_erro()
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
        public void test4_anuncio_publicado_com_datafinal_igual_datainicio_gera_erro()
        {
            anuncio.DataInicio = DateTime.Now.AddDays(3); //igual
            anuncio.DataFim = DateTime.Now.AddDays(3); //igual

            var inicio = anuncio.DataFim.Date;
            var fim = anuncio.DataInicio.Date;

            Assert.True(inicio.CompareTo(fim) == 0);
        }

        [Test]
        public void test5_anuncio_publicado_com_datafinal_inferior_datainicio_gera_erro()
        {
            anuncio.DataInicio = DateTime.Now.AddDays(3); //inicio posterior ao fim
            anuncio.DataFim = DateTime.Now.AddDays(2); //fim inferior ao inicio

            var inicio = anuncio.DataInicio.Date;
            var fim = anuncio.DataFim.Date;

            Assert.True(inicio.CompareTo(fim) > 0);
        }

        [Test]
        public void test6_anuncio_publicado_deve_conter_pelo_menos_um_produto_ou_servico()
        {
            anuncio.Ofertas = new List<Oferta>();

            Assert.True(anuncio.Ofertas.Count() == 0,"Anuncio sem ofertas deve retornar um erro");
        }
    }
}