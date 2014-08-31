using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Endereco: EntityBase<Guid>
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}