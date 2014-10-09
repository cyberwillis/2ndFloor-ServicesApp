using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "EnderecoDTO", Namespace = "dto.am.fiap.com.br")]
    public class EnderecoDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Logradouro { get; set; }
        [DataMember]
        public string Numero { get; set; }
        [DataMember]
        public string Complemento { get; set; }
        [DataMember]
        public string Bairro { get; set; }
        [DataMember]
        public string Cidade { get; set; }
        [DataMember]
        public string Estado { get; set; }
        [DataMember]
        public string Cep { get; set; }
        [DataMember]
        public string AnuncianteId { get; set; }

    }
}