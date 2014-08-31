using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Comentario : EntityBase<Guid>
    {
        public Consumidor Consumidor { get; set; }
        public Anunciante Para { get; set; }
        public string Descricao { get; set; }
        public DateTime Data { get; set; }
        public int Ponto { get; set; }
    }
}