using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using SecondFloor.Infrastructure.Model;
using SecondFloor.Model.UnitTest.Anuncio_Tests;

namespace SecondFloor.Model.UnitTest.Oferta_Tests
{
    [TestFixture]
    public class When_Registering_Oferta
    {
        private Oferta _oferta;
        private Mother _mother;

        [SetUp]
        public void Init()
        {
            _mother = new Mother();
            _oferta = _mother.CreateOferta();
        }

        [Test]
        public void test_oferta_correct_data()
        {
            var expected = 0;
            var actual = _oferta.GetBrokenBusinessRules().Count;

            Assert.AreEqual(expected, actual);
        }

        [Test]
        public void test_oferta_with_improper_data()
        {
            _oferta.Titulo = string.Empty;
            _oferta.Descricao = string.Empty;
            _oferta.Preco = string.Empty;
            _oferta.Endereco = null;

            var brTitulo = new BusinessRule("Titulo", "A oferta não foi informada.");
            var brDescricao = new BusinessRule("Descricao", "A descrição não foi informada.");
            var brPreco = new BusinessRule("Preco", "O preço da oferta não foi informado.");
            var brEndereco = new BusinessRule("Endereco", "A oferta deve conter um endereço.");

            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brTitulo));
            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brDescricao));
            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brPreco));
            Assert.IsTrue(_oferta.GetBrokenBusinessRules().Contains(brEndereco));
        }
    }
}
