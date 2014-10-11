using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Oferta : EntityBase<Guid>
    {
        //Produto ou Serviço
        public virtual string Referencia { get; set; }
        public virtual string NomeProduto { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Fabricante { get; set; }
        public virtual decimal Valor { get; set; }
    }
}