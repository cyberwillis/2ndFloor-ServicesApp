using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.I18n;
using SecondFloor.Model.Rules.Specifications;
using SecondFloor.Model.UnitTest.Anuncio_Tests;

namespace SecondFloor.Model.UnitTest.Endereco_Tests
{
    [TestFixture]
    public class When_Registering_Endereco
    {
        private Endereco _endereco;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();
            _endereco = _mother.CreateEndereco();
        }

        [Test]
        public void test_endereco_correct_data()
        {
            var expected = 0;
            var actual = _endereco.Validate().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void test_endereco_with_improper_data()
        {
            _endereco.Logradouro = string.Empty;
            _endereco.Numero = string.Empty;
            _endereco.Bairro = string.Empty;
            _endereco.Cidade = string.Empty;
            _endereco.Estado = string.Empty;

            var brLogradouro = new Dictionary<string, string>() { { "Logradouro", Resources.Model_Rules_Specification_Endereco_Logradouro_NotNull } };
            var brNumero = new Dictionary<string, string>() { { "Numero", Resources.Model_Rules_Specification_Endereco_Numero_NotNull } };
            var brBairro = new Dictionary<string, string>() { { "Bairro", Resources.Model_Rules_Specification_Endereco_Bairro_NotNull } };
            var brCidade = new Dictionary<string, string>() { { "Cidade", Resources.Model_Rules_Specification_Endereco_Cidade_NotNull } };
            var brEstado = new Dictionary<string, string>() { { "Estado", Resources.Model_Rules_Specification_Endereco_Estado_NotNull } };

            Assert.IsTrue(_endereco.Validate().Contains(brLogradouro.First()));
            Assert.IsTrue(_endereco.Validate().Contains(brNumero.First()));
            Assert.IsTrue(_endereco.Validate().Contains(brBairro.First()));
            Assert.IsTrue(_endereco.Validate().Contains(brCidade.First()));
            Assert.IsTrue(_endereco.Validate().Contains(brEstado.First()));
        }
    }
}
