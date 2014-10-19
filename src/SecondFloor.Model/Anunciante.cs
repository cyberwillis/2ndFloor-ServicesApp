using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Anunciante : EntityBase<Guid>
    {
        public virtual string RazaoSocial { get; set; }
        public virtual string Cnpj { get; set; }
        public virtual string Responsavel { get; set; }
        public virtual string Email { get; set; }
        public virtual int Pontuacao { get; set; }
        public virtual IList<Anuncio> Anuncios { get; set; }
        public virtual IList<Endereco> Enderecos { get; set; }
        public virtual IList<Produto> Produtos { get; set; }
        public virtual IList<Comentario> Comentarios { get; set; }
        //public String Token { get; set; }

        public Anunciante()
        {
            Enderecos = new List<Endereco>();
            Produtos = new List<Produto>();
            Anuncios = new List<Anuncio>();
        }
    }
}