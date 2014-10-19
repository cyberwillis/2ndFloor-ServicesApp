using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "OfertaDTO", Namespace = "dto.secondfloor.com")]
    public class OfertaDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Referencia { get; set; }
        [DataMember]
        public string NomeProduto { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string Fabricante { get; set; }
        [DataMember]
        public string Valor { get; set; }
        [DataMember]
        public EnderecoDto Endereco { get; set; }

        public OfertaDto()
        {
            Endereco = new EnderecoDto();
        }
    }
}