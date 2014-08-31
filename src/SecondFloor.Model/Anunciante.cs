using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Anunciante : EntityBase<Guid>
    {
        public string Cnpj { get; set; }
        public string RazaoSocial { get; set; }
        public virtual IEnumerable<Anuncio> Anuncios { get; set; }
        public virtual IEnumerable<Endereco> Enderecos { get; set; }
        public Comentario Comentario { get; set; }
        public int Pontuacao { get; set; }
        public String Token { get; set; }
    }
}