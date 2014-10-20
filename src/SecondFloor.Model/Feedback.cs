using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Feedback : EntityBase<Guid>
    {
        public virtual decimal Nota { get; set; }
        public virtual string Consumidor { get; set; }
        public virtual string Produto { get; set; }
        //public virtual Anunciante Anunciante { get; set; }
    }
}