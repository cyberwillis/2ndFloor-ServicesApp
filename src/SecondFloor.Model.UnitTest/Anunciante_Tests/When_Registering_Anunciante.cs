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
            anunciante.Cnpj = "49.107.344/0001-93";
            anunciante.Token = "4f2b36ac358c3b311ec5168f561b1325ca1cedde";
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
            var esperado = anunciante.GetToken();
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
            Assert.IsTrue(anunciante.GetBrokenBusinessRules().Contains(expected));
        }
    }
}