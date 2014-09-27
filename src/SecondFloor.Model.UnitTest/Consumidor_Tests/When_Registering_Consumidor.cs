using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.Model.Specifications;
using SecondFloor.Model.UnitTest.Anuncio_Tests;

namespace SecondFloor.Model.UnitTest.Consumidor_Tests
{
    [TestFixture]
    public class When_Registering_Consumidor
    {
        private Consumidor _consumidor;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();
            _consumidor = _mother.CreateConsumidor();
        }

        [Test]
        public void test_consumidor_correct_data()
        {
            var expected = 0;
            var actual = _consumidor.GetBrokenBusinessRules().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void test_consumidor_with_improper_data()
        {
            _consumidor.Nome = string.Empty;
            _consumidor.Email = string.Empty;

            var brNomeNull = new Dictionary<string, string>() {{"Nome", "O nome do consumidor não foi especificado."}};
            var brEmailNUll = new Dictionary<string, string>() {{"Email", "O email do consumidor não foi especificado."}};

            Assert.IsTrue(_consumidor.GetBrokenBusinessRules().Contains(brNomeNull.First()));
            Assert.IsTrue(_consumidor.GetBrokenBusinessRules().Contains(brEmailNUll.First()));
        }

        [Test]
        public void test_consumidor_with_invalid_mail()
        {
            _consumidor.Email = "bolinha";

            var brEmail = new Dictionary<string, string>() {{"Email", "O email do consumidor está inválido."}};
            Assert.IsTrue(_consumidor.GetBrokenBusinessRules().Contains(brEmail.First()));
        }
    }
}
