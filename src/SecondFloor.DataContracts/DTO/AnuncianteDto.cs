using System.Collections.Generic;

namespace SecondFloor.DataContracts.DTO
{
    public class AnuncianteDto
    {
        public string Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Email { get; set; }
        public string Token { get; set; }
        public IList<AnuncioDto> Anuncios { get; set; }
        
    }
}