using NUnit.Framework;
using SecondFloor.Infrastructure;

namespace SecondFloor.Model.UnitTest.Consumidor_Tests
{
    [TestFixture]
    public class When_Registering_Consumidor
    {
        private Consumidor _consumidor;

        [SetUp]
        public void Init()
        {
            _consumidor = new Consumidor();
            _consumidor.Nome = "Rafael dos Anjos";
            _consumidor.Email = "rafael@dosanjos.com.br";
        }

        [Test]
        public void test_consumidor_with_improper_data()
        {
            _consumidor.Nome = string.Empty;
            _consumidor.Email = string.Empty;

            var esperado = 0;
            Assert.Greater( _consumidor.GetBrokenBusinessRules().Count, esperado );
        }

        [Test]
        public void test_consumidor_with_invalid_mail()
        {
            _consumidor.Email = "bolinha";

            var esperado = DocumentosUtil.ValidaEmail(_consumidor.Email);
            Assert.IsFalse(esperado);
        }
    }
}
