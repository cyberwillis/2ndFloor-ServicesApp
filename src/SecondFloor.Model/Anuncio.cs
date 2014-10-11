using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Anuncio : EntityBase<Guid>
    {
        public virtual string Titulo { get; set; }
        public virtual DateTime DataInicio { get; set; }
        public virtual DateTime DataFim { get; set; }
        public virtual AnuncioStatusEnum Status { get; set; }
        public virtual Anunciante Anunciante { get; set; }
        public virtual IList<Oferta> Ofertas { get; set; }

        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Cep { get; set; }

        public Anuncio()
        {
            Ofertas = new List<Oferta>();
        }
    }
}