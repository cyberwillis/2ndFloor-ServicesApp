using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "Oferta")]
    public class OfertaDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string Preco { get; set; }
        [DataMember]
        public EnderecoDto Endereco { get; set; }
    }
}