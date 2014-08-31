using System;
using System.Collections.Generic;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Anuncio : EntityBase<Guid>
    {
        public string Titulo { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public Anunciante Anunciante { get; set; }
        public virtual IEnumerable<Oferta> Ofertas { get; set; }
    }
}