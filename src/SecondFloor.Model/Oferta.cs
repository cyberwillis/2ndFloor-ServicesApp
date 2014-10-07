using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Oferta : EntityBase<Guid>
    {
        //Produto ou Serviço
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Preco { get; set; }
        //public Endereco Endereco { get; set; }
    }
}