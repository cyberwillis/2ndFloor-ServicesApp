using System.Collections.Generic;

namespace SecondFloor.DataContracts.DTO
{
    public class AnuncioDto
    {
        public string Id { get; set; }
        public string Titulo { get; set; }
        public int DiaInicio { get; set; }
        public int MesInicio { get; set; }
        public int AnoInicio { get; set; }
        public int DiaFim { get; set; }
        public int MesFim { get; set; }
        public int AnoFim { get; set; }
        public string AnuncianteToken { get; set; }
        public IEnumerable<OfertaDto> Ofertas { get; set; }
    }
}