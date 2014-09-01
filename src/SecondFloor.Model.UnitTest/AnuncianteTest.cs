using NUnit.Framework;
using SecondFloor.Infrastructure;

namespace SecondFloor.Model.UnitTest
{
    [TestFixture]
    public class AnuncianteTest
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
        public void teste1_anunciante_com_mensagens_de_erro()
        {
            anunciante.RazaoSocial = "";
            anunciante.Cnpj = "";
            anunciante.Token = "";
            anunciante.GetBrokenBusinessRules();

            var esperado = 0;
            Assert.Greater( anunciante.GetBrokenBusinessRules().Count, esperado );
        }

        [Test]
        public void teste2_anunciante_com_token_correto()
        {
            var esperado = Sha1Util.SHA1HashStringForUTF8String( anunciante.Cnpj + anunciante.RazaoSocial );
            Assert.AreEqual( esperado, anunciante.Token );
        }

        [Test]
        public void teste3_anunciante_com_token_invalido()
        {
            //RazaoSocial Incorreto
            anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca.";

            var esperado = Sha1Util.SHA1HashStringForUTF8String(anunciante.Cnpj + anunciante.RazaoSocial);
            Assert.AreNotEqual(esperado, anunciante.Token);
        }

        [Test]
        public void teste4_anunciante_com_cnpj_invalido()
        {
            //Cnpj incorreto
            anunciante.Cnpj = "40.123.456.0001-20";

            var esperado = DocumentosUtil.ValidaCnpj(anunciante.Cnpj);
            Assert.IsFalse(esperado);
        }
    }
}