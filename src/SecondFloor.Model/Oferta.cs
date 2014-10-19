using System;
using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Model
{
    public class Oferta : EntityBase<Guid>
    {
        //Produto ou Serviço
        public virtual string NomeProduto { get; set; }
        public virtual string Referencia { get; set; }
        public virtual string Descricao { get; set; }
        public virtual string Fabricante { get; set; }
        public virtual decimal Valor { get; set; }
        //public virtual Anuncio Anuncio { get; set; }

        public virtual string Logradouro { get; set; }
        public virtual string Numero { get; set; }
        public virtual string Complemento { get; set; }
        public virtual string Bairro { get; set; }
        public virtual string Cidade { get; set; }
        public virtual string Estado { get; set; }
        public virtual string Cep { get; set; }
    }
}