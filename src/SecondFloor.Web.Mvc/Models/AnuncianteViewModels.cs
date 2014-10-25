using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SecondFloor.I18n;

namespace SecondFloor.Web.Mvc.Models
{
    public class AnuncianteViewModels
    {
        public string Id { get; set; }

        [Display(Name = "AnuncianteViewModels_AttributeName_Responsavel",ResourceType = typeof(Resources))]
        public string NomeResponsavel { get; set; }

        [Display(Name = "AnuncianteViewModels_AttributeName_Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = "AnuncianteViewModels_AttributeName_RazaoSocial", ResourceType = typeof(Resources))]
        public string RazaoSocial { get; set; }

        [Display(Name = "AnuncianteViewModels_AttributeName_CNPJ", ResourceType = typeof(Resources))]
        public string Cnpj { get; set; }

        public ICollection<EnderecoViewModels> Enderecos { get; set; }
    }
}