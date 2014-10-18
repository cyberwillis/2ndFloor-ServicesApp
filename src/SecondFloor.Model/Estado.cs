using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Estado : EntityBase<int>
    {
        public virtual string Nome { get; set; }
        public virtual string Sigla { get; set; }
        //public virtual Endereco Endereco { get; set; }
    }
}