using System.Collections.Generic;

namespace SecondFloor.Web.Mvc.Models
{
    public class AnuncioViewModels
    {
        public string Id { get; set; }

        public string Titulo { get; set; }

        public string DataInicio { get; set; }
        public string DataFim { get; set; }
        public IList<OfertaViewModels> Ofertas { get; set; }

        public string Status { get; set; }

        public string Logradouro { get; set; }
        public string Numero { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public string AnuncianteId { get; set; }
    }
}