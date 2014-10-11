using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Endereco: EntityBase<Guid>
    {
        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Cep { get; set; }
        public virtual Anunciante Anunciante { get; set; }
    }
}