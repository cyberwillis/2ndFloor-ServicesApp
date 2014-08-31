using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Consumidor : EntityBase<Guid>
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public TipoAcesso TipoAcesso { get; set; }
    }
}