using System.Collections.Generic;
using System.Runtime.Serialization;

namespace SecondFloor.DataContracts.DTO
{
    [DataContract(Name = "AnuncioDTO", Namespace = "dto.am.fiap.com.br")]
    public class AnuncioDto
    {
        [DataMember]
        public string Id { get; set; }
        [DataMember]
        public string Titulo { get; set; }
        [DataMember]
        public int DiaInicio { get; set; }
        [DataMember]
        public int MesInicio { get; set; }
        [DataMember]
        public int AnoInicio { get; set; }
        [DataMember]
        public int DiaFim { get; set; }
        [DataMember]
        public int MesFim { get; set; }
        [DataMember]
        public int AnoFim { get; set; }

        //public string AnuncianteToken { get; set; }
        [DataMember]
        public IEnumerable<OfertaDto> Ofertas { get; set; }
    }
}