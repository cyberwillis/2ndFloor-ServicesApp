using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Anunciante: EntityBase<Guid>
    {
        public string RazaoSocial { get; set; }
    }
}