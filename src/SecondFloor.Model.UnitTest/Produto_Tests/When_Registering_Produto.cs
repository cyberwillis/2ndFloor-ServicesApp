using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.I18n;
using SecondFloor.Model.Rules.Specifications;

namespace SecondFloor.Model.UnitTest.Anuncio_Tests.Produto_Tests
{
    [TestFixture]
    public class When_Registering_Produto
    {
        private Produto _produto;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();
            _produto = _mother.CreateProduto();
        }

        [Test]
        public void test_produto_with_improper_data()
        {
            _produto.NomeProduto = string.Empty;
            _produto.Referencia = string.Empty;
            _produto.Fabricante = string.Empty;
            _produto.Descricao = string.Empty;

            var brNomeProduto = new Dictionary<string, string>() { { "NomeProduto", Resources.Model_Rules_Produto_Specification_NomeProduto_NotNull } };
            var brReferencia = new Dictionary<string, string>() { { "Descricao", Resources.Model_Rules_Produto_Specification_Descricao_NotNull } };
            //var brFabricante = new Dictionary<string, string>() { { "", "" } };
            //var brDescricao = new Dictionary<string, string>() { { "", "" } };

            Assert.IsTrue(_produto.Validate().Contains(brNomeProduto.First()));
            Assert.IsTrue(_produto.Validate().Contains(brReferencia.First()));
        }

    }
}
