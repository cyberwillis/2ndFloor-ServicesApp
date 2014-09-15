using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SecondFloor.Infrastructure.Model;
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
            var actual = _endereco.GetBrokenBusinessRules().Count;

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

            var brLogradouro = new BusinessRule("Logradouro", "O logradouro não foi especificado.");
            var brNumero = new BusinessRule("Numero", "O número do logradouro não foi especificado.");
            var brBairro = new BusinessRule("Bairro", "O bairro não foi especificado.");
            var brCidade = new BusinessRule("Cidade", "A cidade não foi especificada.");
            var brEstado = new BusinessRule("Estado", "O estado não foi especificado.");

            Assert.IsTrue(_endereco.GetBrokenBusinessRules().Contains(brLogradouro));
            Assert.IsTrue(_endereco.GetBrokenBusinessRules().Contains(brNumero));
            Assert.IsTrue(_endereco.GetBrokenBusinessRules().Contains(brBairro));
            Assert.IsTrue(_endereco.GetBrokenBusinessRules().Contains(brCidade));
            Assert.IsTrue(_endereco.GetBrokenBusinessRules().Contains(brEstado));
        }
    }
}
