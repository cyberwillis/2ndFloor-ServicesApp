using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "EstadoDTO", Namespace = "dto.secondfloor.com")]
    public class EstadoDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Nome { get; set; }
        [DataMember]
        public string Sigla { get; set; }
    }
}