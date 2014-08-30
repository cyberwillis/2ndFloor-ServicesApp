using NUnit.Framework;

namespace SecondFloor.Model.UnitTest
{
    [TestFixture]
    public class AnuncianteTest
    {
        [Test]
        public void teste1_anunciante_com_mensagens_de_erro()
        {
            var anunciante = new Anunciante();
            anunciante.RazaoSocial = "";
            anunciante.GetBrokenBusinessRules();

            var esperado = 0;
            Assert.Greater( anunciante.GetBrokenBusinessRules().Count, esperado );
        }
    }
}