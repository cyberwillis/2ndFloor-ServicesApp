using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SecondFloor.I18n;

namespace SecondFloor.Web.Mvc.Models
{
    public class AnuncioViewModels
    {
        public string Id { get; set; }

        [Display(Name = "AnuncioViewModel_AttributeName_Titulo", ResourceType = typeof(Resources))]
        public string Titulo { get; set; }

        [Display(Name = "AnuncioViewModel_AttributeName_DataInicio", ResourceType = typeof(Resources))]
        public string DataInicio { get; set; }

        [Display(Name = "AnuncioViewModel_AttributeName_DataFim", ResourceType = typeof(Resources))]
        public string DataFim { get; set; }

        [Display(Name = "AnuncioViewModel_AttributeName_Status", ResourceType = typeof(Resources))]
        public string Status { get; set; }

        public string EnderecoId { get; set; }

        [Display(Name = "AnuncioViewModel_AttributeName_Enderecos", ResourceType = typeof(Resources))]
        public EnderecoViewModels Endereco { get; set; }

        public IList<EnderecoViewModels> Enderecos { get; set; }

        [Display(Name = "AnuncioViewModel_AttributeName_Ofertas", ResourceType = typeof(Resources))]
        public IList<OfertaViewModels> Ofertas { get; set; }

        public string AnuncianteId { get; set; }
        
        public SelectList GetEnderecosSelectList()
        {
            var list = new List<EnderecoViewModels>();

            if (Enderecos != null)
            {
                list.AddRange(Enderecos);
            }

            return new SelectList(list, "Id", "LogradouroCompleto");
        }

        public AnuncioViewModels()
        {
            Endereco = new EnderecoViewModels();
        }
    }
}