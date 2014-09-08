using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.Infrastructure;
using SecondFloor.Infrastructure.Model;

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

            var brRazaoSocial = new BusinessRule("Razao Social","A razão social não pode ser nula.");
            var brCNPJ = new BusinessRule("Cnpj", "O Cnpj não pode ser nulo.");
            var brToken = new BusinessRule("Token", "Erro no cadastro do Anunciante, ficará impossibilitado de publicar ofertas");

            Assert.IsTrue(anunciante.GetBrokenBusinessRules().Contains(brRazaoSocial));
            Assert.IsTrue(anunciante.GetBrokenBusinessRules().Contains(brCNPJ));
            Assert.IsTrue(anunciante.GetBrokenBusinessRules().Contains(brToken));
        }

        [Test]
        public void test_anunciante_with_correct_token()
        {
            //TODO: (RAFAEL) Refactoring Encapsular Regra de criação de Token Anunciante
            var esperado = Sha1Util.SHA1HashStringForUTF8String( anunciante.Cnpj + anunciante.RazaoSocial );
            Assert.AreEqual( esperado, anunciante.Token );
        }

        [Test]
        public void test_anunciante_with_invalid_token()
        {
            //RazaoSocial Incorreto
            anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca.";

            var expected = new BusinessRule("Token", "O Token do anunciante não confere");
            Assert.IsTrue(anunciante.GetBrokenBusinessRules().Contains(expected));
        }

        [Test]
        public void test_anunciante_with_invalid_cnpj()
        {
            //Cnpj incorreto
            anunciante.Cnpj = "40.123.456.0001-20";

            var expected = new BusinessRule("Cnpj", "O Cnpj está invalido");
            IList<BusinessRule> br = anunciante.GetBrokenBusinessRules();

            Assert.IsTrue(anunciante.GetBrokenBusinessRules().Contains(expected));
        }
    }
}