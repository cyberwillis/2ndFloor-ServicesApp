using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "OfertaDTO", Namespace = "dto.secondfloor.com")]
    public class ConsumidorOfertaDto
    {
        [DataMember]
        public string OfertaId { get; set; }
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
        public EstadoDto Estado { get; set; }
        [DataMember]
        public string Cep { get; set; }

        [DataMember]
        public string AnuncianteId { get; set; }
        [DataMember]
        public string AnuncianteRazaoSocial { get; set; }
        [DataMember]
        public string AnunciantePontuacao { get; set; }
    }
}