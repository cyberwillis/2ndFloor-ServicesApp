using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Usuario : EntityBase<Guid>
    {
        public string Login { get; set; }
        public string Password { get; set; }
    }
}