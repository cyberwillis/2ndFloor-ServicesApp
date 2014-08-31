using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Oferta : EntityBase<Guid>
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public double Preco { get; set; }
        public Endereco Endereco { get; set; }
    }
}