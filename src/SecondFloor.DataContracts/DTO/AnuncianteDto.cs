using System.Collections.Generic;

namespace SecondFloor.DataContracts.DTO
{
    public class AnuncianteDto
    {
        public string RazaoSocial;
        public string Cnpj;
        public string Email;
        public string Token;
        public IList<AnuncioDto> Anuncios;
    }
}