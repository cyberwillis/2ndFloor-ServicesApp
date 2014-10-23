using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "OfertaDTO", Namespace = "dto.secondfloor.com")]
    public class ConsumidorOfertaDto
    {
        [DataMember(Name = "ofertaId")]
        public string OfertaId { get; set; }
        [DataMember(Name = "referencia")]
        public string Referencia { get; set; }
        [DataMember(Name = "nomeProduto")]
        public string NomeProduto { get; set; }
        [DataMember(Name = "descricao")]
        public string Descricao { get; set; }
        [DataMember(Name = "fabricante")]
        public string Fabricante { get; set; }
        [DataMember(Name = "valor")]
        public string Valor { get; set; }

        [DataMember(Name = "logradouro")]
        public string Logradouro { get; set; }
        [DataMember(Name = "numero")]
        public string Numero { get; set; }
        [DataMember(Name = "complemento")]
        public string Complemento { get; set; }
        [DataMember(Name = "bairro")]
        public string Bairro { get; set; }
        [DataMember(Name = "cidade")]
        public string Cidade { get; set; }
        [DataMember(Name = "estado")]
        public EstadoDto Estado { get; set; }
        [DataMember(Name = "cep")]
        public string Cep { get; set; }

        [DataMember(Name = "anuncianteId")]
        public string AnuncianteId { get; set; }
        [DataMember(Name = "anuncianteRazaoSocial")]
        public string AnuncianteRazaoSocial { get; set; }
        [DataMember(Name = "anunciantePontuacao")]
        public string AnunciantePontuacao { get; set; }

        [DataMember(Name = "dataInicio")]
        public string DataInicio { get; set; }
        [DataMember(Name = "dataFim")]
        public string DataFim { get; set; }
    }
}