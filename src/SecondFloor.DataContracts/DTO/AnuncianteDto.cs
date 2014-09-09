using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "Anunciante")]
    public class AnuncianteDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string RazaoSocial { get; set; }
        [DataMember]
        public string Cnpj { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Token { get; set; }
        [DataMember]
        public IList<AnuncioDto> Anuncios { get; set; }
        
    }
}