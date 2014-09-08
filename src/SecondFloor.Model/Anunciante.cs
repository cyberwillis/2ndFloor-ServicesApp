using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Anunciante : EntityBase<Guid>
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public string Email { get; set; }
        public virtual IList<Anuncio> Anuncios { get; set; }
        //public virtual IList<Endereco> Enderecos { get; set; }
        public IList<Comentario> Comentarios { get; set; }
        public int Pontuacao { get; set; }
        public String Token { get; set; }

        public Anunciante()
        {
            Anuncios = new List<Anuncio>();
        }
    }
}