using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
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

            var brResponsavel = new Dictionary<string, string>() { { "Responsavel", "O Responsável não pode ser nulo." } };
            var brEmail = new Dictionary<string, string>() { { "Email", "O Email não pode ser nulo." } };
            var brRazaoSocial = new Dictionary<string, string>() {{"Razao Social", "A razão social não pode ser nula."}};
            var brCNPJ = new Dictionary<string, string>() {{"Cnpj", "O Cnpj não pode ser nulo."}};

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

            var expected = new Dictionary<string,string>(){{"Cnpj", "O Cnpj está invalido"}};
            Assert.IsTrue(anunciante.Validate().Contains(expected.First()));
        }

        [Test]
        public void teste_anunciante_with_invalid_email()
        {
            //Email incorreto
            anunciante.Email = "fulano";

            var expected = new Dictionary<string, string>() { { "Email", "O Email está invalido" } };
            Assert.IsTrue(anunciante.Validate().Contains(expected.First()));
        }
    }
}