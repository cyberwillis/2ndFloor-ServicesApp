using System;
using NUnit.Framework;

namespace SecondFloor.Model.UnitTest.Comentario_Tests
{
    [TestFixture]
    public class When_Registering_Comentario
    {
        private Comentario _comentario;
        private Consumidor _consumidor;
        private Anunciante _anunciante;

        [SetUp]
        public void Init()
        {
            CreateAnunciante();
            CreateConsumidor();
            _comentario = new Comentario();
            _comentario.Consumidor = _consumidor;
            _comentario.Para = _anunciante;
            _comentario.Descricao = "Enchendo linguiça .com";
            _comentario.Data = DateTime.Now;
            _comentario.Ponto = 5;
        }


        [Test]
        public void test_comentario_with_correct_data()
        {
            var esperado = 0;
            Assert.AreEqual(_comentario.GetBrokenBusinessRules().Count, esperado);
        }

        [Test]
        public void test_comentario_with_improper_data()
        {
            _comentario.Consumidor = null;
            _comentario.Para = null;
            _comentario.Descricao = string.Empty;
            _comentario.Data = DateTime.Now.AddDays(-3);
            _comentario.Ponto = 0;

            var esperado = 0;
            Assert.Greater(_comentario.GetBrokenBusinessRules().Count, esperado);
        }

        private void CreateConsumidor()
        {
            _consumidor = new Consumidor();
            _consumidor.Nome = "Rafael dos Anjos";
            _consumidor.Email = "rafael@dosanjos.com.br";
        }

        private void CreateAnunciante()
        {
            _anunciante = new Anunciante();
            _anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            _anunciante.Cnpj = "49.107.344/0001-93";
            _anunciante.Token = "4f2b36ac358c3b311ec5168f561b1325ca1cedde";
        }
    }
}