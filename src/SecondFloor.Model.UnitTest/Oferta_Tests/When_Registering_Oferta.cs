using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.Model.Rules.Specifications;
using SecondFloor.Model.UnitTest.Anuncio_Tests;

namespace SecondFloor.Model.UnitTest.Oferta_Tests
{
    [TestFixture]
    public class When_Registering_Oferta
    {
        private Oferta _oferta;
        private Mother _mother;

        /*[SetUp]
        public void Init()
        {
            _mother = new Mother();
            _oferta = _mother.CreateOferta();
        }

        [Test]
        public void test_oferta_correct_data()
        {
            var expected = 0;
            var actual = _oferta.GetBrokenBusinessRules().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void test_oferta_with_improper_data()
        {
            _oferta.Titulo = string.Empty;
            _oferta.Descricao = string.Empty;
            _oferta.Preco = string.Empty;
            _oferta.Endereco = null;

            var brTitulo = new Dictionary<string, string>() {{"Titulo", "A oferta não foi informada."}};
            var brDescricao = new Dictionary<string, string>() {{"Descricao", "A descrição não foi informada."}};
            var brPreco = new Dictionary<string, string>() {{"Preco", "O preço da oferta não foi informado."}};
            var brEndereco = new Dictionary<string, string>() {{"Endereco", "A oferta deve conter um endereço."}};

            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brTitulo.First()));
            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brDescricao.First()));
            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brPreco.First()));
            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brEndereco.First()));
        }*/
    }
}
