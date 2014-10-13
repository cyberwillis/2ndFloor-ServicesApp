using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Comentario : EntityBase<Guid>
    {
        public virtual Consumidor Consumidor { get; set; }
        public virtual Anunciante Para { get; set; }
        public virtual string Descricao { get; set; }
        public virtual DateTime Data { get; set; }
        public virtual int Ponto { get; set; }
    }
}