using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using SecondFloor.I18n;
using SecondFloor.Model.Rules.Specifications;
using SecondFloor.Model.UnitTest.Anuncio_Tests;

namespace SecondFloor.Model.UnitTest.Anunciante_Tests
{
    [TestFixture]
    public class When_Registering_Anunciante
    {
        private Anunciante anunciante;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother =new Mother();
            anunciante = _mother.CreateAnunciante();
        }

        [Test]
        public void test_anunciante_with_improper_data()
        {
            anunciante.Responsavel = "";
            anunciante.Email = "";
            anunciante.RazaoSocial = "";
            anunciante.Cnpj = "";

            var brResponsavel = new Dictionary<string, string>() { { "NomeResponsavel", Resources.Model_Rules_Specification_Anunciante_NomeResponsavel_NotNull } };
            var brEmail = new Dictionary<string, string>() { { "Email", Resources.Model_Rules_Specification_Anunciante_Email_NotNull } };
            var brRazaoSocial = new Dictionary<string, string>() { { "RazaoSocial", Resources.Model_Rules_Specification_Anunciante_RazaoSocial_NotNull } };
            var brCNPJ = new Dictionary<string, string>() { { "Cnpj", Resources.Model_Rules_Specification_Anunciante_Cnpj_NotNull } };

            Assert.IsTrue(anunciante.Validate().Contains(brResponsavel.First()));
            Assert.IsTrue(anunciante.Validate().Contains(brEmail.First()));
            Assert.IsTrue(anunciante.Validate().Contains(brRazaoSocial.First()));
            Assert.IsTrue(anunciante.Validate().Contains(brCNPJ.First()));
        }

        [Test]
        public void test_anunciante_with_invalid_cnpj()
        {
            //Cnpj incorreto
            anunciante.Cnpj = "40.123.456.0001-20";

            var expected = new Dictionary<string, string>() { { "Cnpj", Resources.Model_Rules_Specification_Anunciante_Cnpj_Invalid } };
            Assert.IsTrue(anunciante.Validate().Contains(expected.First()));
        }

        [Test]
        public void teste_anunciante_with_invalid_email()
        {
            //Email incorreto
            anunciante.Email = "fulano";

            var expected = new Dictionary<string, string>() { { "Email", Resources.Model_Rules_Specification_Anunciante_Email_Invalid } };
            Assert.IsTrue(anunciante.Validate().Contains(expected.First()));
        }
    }
}