using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Produto : EntityBase<Guid>
    {
        public virtual string NomeProduto { get; set; }
        public virtual string Referencia { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Fabricante { get; set; }
        public virtual decimal Valor { get; set; }
        public virtual Anunciante Anunciante { get; set; }
    }
}