using System.Threading;
using NUnit.Framework;
using SecondFloor.Infrastructure;
using SecondFloor.Infrastructure.Model;
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

            var brNomeNull = new BusinessRule("Nome", "O nome do consumidor não foi especificado.");
            var brEmailNUll = new BusinessRule("Email", "O email do consumidor não foi especificado.");

            Assert.IsTrue(_consumidor.GetBrokenBusinessRules().Contains(brNomeNull));
            Assert.IsTrue(_consumidor.GetBrokenBusinessRules().Contains(brEmailNUll));
        }

        [Test]
        public void test_consumidor_with_invalid_mail()
        {
            _consumidor.Email = "bolinha";

            var brEmail = new BusinessRule("Email", "O email do consumidor está inválido.");
            Assert.IsTrue(_consumidor.GetBrokenBusinessRules().Contains(brEmail));
        }
    }
}
