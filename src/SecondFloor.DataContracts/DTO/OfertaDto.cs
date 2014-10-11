using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "OfertaDTO", Namespace = "dto.am.fiap.com.br")]
    public class OfertaDto
    {
        [DataMember]
        public string Id { get; set; }
        public string Referencia { get; set; }
        [DataMember]
        public string NomeProduto { get; set; }
        [DataMember]
        public string Descricao { get; set; }
        [DataMember]
        public string Fabricante { get; set; }
        [DataMember]
        public string Valor { get; set; }
    }
}