using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model.UnitTest.Anuncio_Tests
{
    public class When_Registering_Anuncio
    {
        private Anuncio _anuncio;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();
            _anuncio = _mother.CreateAnuncio();
        }
        
        [Test]
        public void test_anuncio_correct_data()
        {
            var expected = 0;
            var actual = _anuncio.GetBrokenBusinessRules().Count;

            Assert.AreEqual(expected, actual);
        }
        [Test]
        public void test_anuncio_without_titulo()
        {
            _anuncio.Titulo = string.Empty;

            var brTitulo = new BusinessRule("Titulo", "O titulo do anúncio não foi especificado.");

            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brTitulo));
        }

        [Test]
        public void test_anuncio_with_datainicio_before_dataatual()
        {
            _anuncio.DataInicio = DateTime.Now.AddDays(-1); //ontem Data da publicação

            var brDataInicio = new BusinessRule("Data Inicio","Estas ofertas devem possuir uma data de inicio posterior a de hoje.");

            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brDataInicio));
        }

        [Test]
        public void test_anuncio_with_datainicio_with_same_dataatual()
        {
            _anuncio.DataFim = DateTime.Now; //hj

            var brDataInicio = new BusinessRule("Data Inicio","Estas ofertas devem possuir uma data de inicio diferente da data de fim.");
            var brDataFim = new BusinessRule("Data Fim", "Estas ofertas devem possuir uma data de fim diferente da data de inicio.");
            
            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brDataInicio));
            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brDataFim));
        }

        //Teoricamente na Specification do Anuncio a data do _anuncio deve ser superior ao dia de hoje, regra esta que invibiliza esta.
        //[Test]
        //public void test_anuncio_with_datainicio_after_dataatual()
        //{
        //    var esperado = 0;
        //    _anuncio.DataInicio = DateTime.Now.AddDays(1);  //amanha

        //    //data _anuncio é POSTERIOR data de publicacao
        //    var dataPublicacao = _anuncio.DataInicio;
        //    var dataAtual = DateTime.Now;
        //    var comparacao = dataAtual.Date.CompareTo(dataPublicacao.Date);

        //    Assert.Less(comparacao, esperado);
        //}

        [Test]
        public void test_anuncio_with_datafinal_equal_datainicio()
        {
            _anuncio.DataInicio = DateTime.Now.AddDays(3); //igual
            _anuncio.DataFim = DateTime.Now.AddDays(3); //igual

            var brDataInicio = new BusinessRule("Data Inicio", "Estas ofertas devem possuir uma data de inicio diferente da data de fim.");
            var brDataFim = new BusinessRule("Data Fim", "Estas ofertas devem possuir uma data de fim diferente da data de inicio.");

            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brDataInicio));
            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brDataFim));
        }

        [Test]
        public void test_anuncio_with_datafinal_before_datainicio()
        {
            _anuncio.DataInicio = DateTime.Now.AddDays(3); //inicio posterior ao fim
            _anuncio.DataFim = DateTime.Now.AddDays(2); //fim inferior ao inicio

            var brDataFim = new BusinessRule("Data Fim", "Estas ofertas devem possuir uma data de fim posterior a de inicio.");
            
            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brDataFim));
        }

        [Test]
        public void test_anuncio_must_have_at_least_one_oferta()
        {
            _anuncio.Ofertas = null;

            var brOfertas = new BusinessRule("Oferas", "A publicação da oferta precisa conter produtos ou serviços.");
            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brOfertas));

            _anuncio.Ofertas = new List<Oferta>();
            Assert.IsTrue(_anuncio.GetBrokenBusinessRules().Contains(brOfertas));
        }
    }
}