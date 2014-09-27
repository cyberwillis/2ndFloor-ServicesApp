using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.Model.Specifications;
using SecondFloor.Model.UnitTest.Anuncio_Tests;
using Enumerable = System.Linq.Enumerable;

namespace SecondFloor.Model.UnitTest.Comentario_Tests
{
    [TestFixture]
    public class When_Registering_Comentario
    {
        private Comentario _comentario;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();
            _comentario = _mother.CreateComentario();
        }


        [Test]
        public void test_comentario_with_correct_data()
        {
            var esperado = 0;
            Assert.AreEqual(_comentario.GetBrokenBusinessRules().Count, esperado);
        }

        [Test]
        public void test_comentario_with_improper_data()
        {
            _comentario.Consumidor = null;
            _comentario.Para = null;
            _comentario.Descricao = string.Empty;
            _comentario.Data = DateTime.Now.AddDays(-3);
            _comentario.Ponto = 0;

            var brConsumidor = new Dictionary<string, string>() {{"Cosumidor", "O consumidor não foi especificado."}};
            var brAnunciante = new Dictionary<string, string>() {{"Para", "O anunciante não foi especificado."}};
            var brDescricao = new Dictionary<string, string>() {{"Descricao", "A descrição deve possuir no mínimo (3) caracteres."}};
            var brData = new Dictionary<string, string>() {{"Data", "A data esta diferente do dia atual."}};
            var brPonto = new Dictionary<string, string>() {{"Ponto", "Pontuação deve ser no mínimo 1."}};
         
            Assert.IsTrue(_comentario.GetBrokenBusinessRules().Contains(brConsumidor.First()));
            Assert.IsTrue(_comentario.GetBrokenBusinessRules().Contains(brAnunciante.First()));
            Assert.IsTrue(_comentario.GetBrokenBusinessRules().Contains(brDescricao.First()));
            Assert.IsTrue(_comentario.GetBrokenBusinessRules().Contains(brData.First()));
            Assert.IsTrue(_comentario.GetBrokenBusinessRules().Contains(brPonto.First()));
        }
    }
}