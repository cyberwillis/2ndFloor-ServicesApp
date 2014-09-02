using NUnit.Framework;
using SecondFloor.Infrastructure;

namespace SecondFloor.Model.UnitTest.Anunciante_Tests
{
    [TestFixture]
    public class When_Registering_Anunciante
    {
        private Anunciante anunciante;

        [SetUp]
        public void Init()
        {
            anunciante = new Anunciante();
            anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            anunciante.Cnpj = "40.123.456.0001-10";
            anunciante.Token = "62ac3355aedf50d4304cc0882a38cf5ef17eb764";
        }

        [Test]
        public void test_anunciante_with_improper_data()
        {
            anunciante.RazaoSocial = "";
            anunciante.Cnpj = "";
            anunciante.Token = "";
            anunciante.GetBrokenBusinessRules();

            var esperado = 0;
            Assert.Greater( anunciante.GetBrokenBusinessRules().Count, esperado );
        }

        [Test]
        public void test_anunciante_with_correct_token()
        {
            var esperado = Sha1Util.SHA1HashStringForUTF8String( anunciante.Cnpj + anunciante.RazaoSocial );
            Assert.AreEqual( esperado, anunciante.Token );
        }

        [Test]
        public void test_anunciante_with_invalid_token()
        {
            //RazaoSocial Incorreto
            anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca.";

            var esperado = Sha1Util.SHA1HashStringForUTF8String(anunciante.Cnpj + anunciante.RazaoSocial);
            Assert.AreNotEqual(esperado, anunciante.Token);
        }

        [Test]
        public void test_anunciante_with_invalid_cnpj()
        {
            //Cnpj incorreto
            anunciante.Cnpj = "40.123.456.0001-20";

            var esperado = DocumentosUtil.ValidaCnpj(anunciante.Cnpj);
            Assert.IsFalse(esperado);
        }
    }
}