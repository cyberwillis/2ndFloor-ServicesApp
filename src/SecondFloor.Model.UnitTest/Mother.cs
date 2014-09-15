using System;
using System.Collections.Generic;

namespace SecondFloor.Model.UnitTest.Anuncio_Tests
{
    /// <summary>
    /// TDD ObjectMotherPattern
    /// http://martinfowler.com/bliki/ObjectMother.html
    /// For Complex class or business rules use Test Data Builder Pattern
    /// http://geekswithblogs.net/Podwysocki/archive/2008/01/08/118362.aspx
    /// </summary>
    public class Mother
    {
        public Anunciante CreateAnunciante()
        {
            var anunciante = new Anunciante();
            anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            anunciante.Cnpj = "49.107.344/0001-93";
            anunciante.Token = "4f2b36ac358c3b311ec5168f561b1325ca1cedde";

            return anunciante;
        }

        public Endereco CreateEndereco()
        {
            var endereco = new Endereco();
            endereco.Logradouro = "Rua Xpto";
            endereco.Numero = "1024";
            endereco.Bairro = "De algum lugar";
            endereco.Cidade = "Tão Tão distante";
            endereco.Estado = "SP";
            endereco.CEP = "09424-000";

            return endereco;
        }

        public List<Oferta> CreateOfertas()
        {
            var ofertas = new List<Oferta>();

            var oferta = new Oferta();
            oferta.Titulo = "Um produto qualquer.";
            oferta.Descricao = "Descrição de um produto qualquer.";
            oferta.Preco = "10.00";
            oferta.Endereco = this.CreateEndereco();

            ofertas.Add(oferta);
            return ofertas;
        }

        public Anuncio CreateAnuncio()
        {
            var anuncio = new Anuncio();
            anuncio.Titulo = "Ofertas Relampago";
            anuncio.DataInicio = DateTime.Now;
            anuncio.DataFim = DateTime.Now.AddDays(7);
            anuncio.Ofertas = this.CreateOfertas();
            anuncio.Anunciante = this.CreateAnunciante();
            return anuncio;
        }

        public Consumidor CreateConsumidor()
        {
            var consumidor = new Consumidor();
            consumidor.Nome = "Rafael dos Anjos";
            consumidor.Email = "rafael@dosanjos.com.br";

            return consumidor;
        }

        public Comentario CreateComentario()
        {
            var comentario = new Comentario();
            comentario.Consumidor = this.CreateConsumidor();
            comentario.Para = this.CreateAnunciante();
            comentario.Descricao = "Enchendo linguiça .com";
            comentario.Data = DateTime.Now;
            comentario.Ponto = 5;

            return comentario;
        }
    }
}