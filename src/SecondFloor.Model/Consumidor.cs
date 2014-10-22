using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Consumidor : EntityBase<Guid>
    {
        public virtual string Nome { get; set; }
        public virtual string Email { get; set; }
        public virtual TipoAcesso TipoAcesso { get; set; }
        public virtual string Token { get; set; }
    }
}