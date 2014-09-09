using System;
using System.Collections.Generic;

namespace SecondFloor.Model.UnitTest.Anuncio_Tests
{
    public class Builder
    {
        public Anunciante ValidAnunciante()
        {
            var anunciante = new Anunciante();
            anunciante.RazaoSocial = "Oficina de entretenimento adulto do tio careca";
            anunciante.Cnpj = "49.107.344/0001-93";
            anunciante.Token = "4f2b36ac358c3b311ec5168f561b1325ca1cedde";

            return anunciante;
        }

        public Endereco ValidEndereco()
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

        public List<Oferta> ValidOfertas()
        {
            var ofertas = new List<Oferta>();

            var oferta = new Oferta();
            oferta.Titulo = "Um produto qualquer.";
            oferta.Descricao = "Descrição de um produto qualquer.";
            oferta.Preco = "10.00";
            oferta.Endereco = this.ValidEndereco();

            ofertas.Add(oferta);
            return ofertas;
        }

        public Anuncio ValidAnuncio()
        {
            var anuncio = new Anuncio();
            anuncio.Titulo = "Ofertas Relampago";
            anuncio.DataInicio = DateTime.Now;
            anuncio.DataFim = DateTime.Now.AddDays(7);
            anuncio.Ofertas = this.ValidOfertas();
            anuncio.Anunciante = this.ValidAnunciante();
            return anuncio;
        }

        public Consumidor ValidConsumidor()
        {
            var consumidor = new Consumidor();
            consumidor.Nome = "Rafael dos Anjos";
            consumidor.Email = "rafael@dosanjos.com.br";

            return consumidor;
        }

        public Comentario ValidComentario()
        {
            var comentario = new Comentario();
            comentario.Consumidor = this.ValidConsumidor();
            comentario.Para = this.ValidAnunciante();
            comentario.Descricao = "Enchendo linguiça .com";
            comentario.Data = DateTime.Now;
            comentario.Ponto = 5;

            return comentario;
        }
    }
}