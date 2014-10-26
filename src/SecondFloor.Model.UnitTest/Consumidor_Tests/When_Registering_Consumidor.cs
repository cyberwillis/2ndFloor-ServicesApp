using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.I18n;
using SecondFloor.Model.Rules.Specifications;
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
            var actual = _consumidor.Validate().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void test_consumidor_with_improper_data()
        {
            _consumidor.Nome = string.Empty;
            _consumidor.Email = string.Empty;

            var brNomeNull = new Dictionary<string, string>() { { "Nome", Resources.Model_Rules_Specification_Consumidor_Nome_NotNull } };
            var brEmailNUll = new Dictionary<string, string>() { { "Email", Resources.Model_Rules_Specification_Consumidor_Email_NotNull } };

            Assert.IsTrue(_consumidor.Validate().Contains(brNomeNull.First()));
            Assert.IsTrue(_consumidor.Validate().Contains(brEmailNUll.First()));
        }

        [Test]
        public void test_consumidor_with_invalid_mail()
        {
            _consumidor.Email = "bolinha";

            var brEmail = new Dictionary<string, string>() { { "Email", Resources.Model_Rules_Specification_Consumidor_Email_Invalid } };
            Assert.IsTrue(_consumidor.Validate().Contains(brEmail.First()));
        }
    }
}
