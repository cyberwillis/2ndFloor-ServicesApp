using System.ComponentModel.DataAnnotations;

namespace SecondFloor.Web.Mvc.Models
{
    public class EnderecoViewModels
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo logradouro não pode ser nulo",AllowEmptyStrings = false)]
        [MinLength(  6,ErrorMessage = "O campo logradouro deve ter ao menos (6) caracteres.")]
        [MaxLength(250,ErrorMessage = "O campo logradouro deve ter no máximo (250) caracteres.")]
        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Required(ErrorMessage = "O campo numero não pode ser nulo", AllowEmptyStrings = true)]
        //[MaxLength(5, ErrorMessage = "O campo numero nao pode possuir mais de 5 caracteres.")]
        //[RegularExpression(@"^\d+$", ErrorMessage = "Entre somente numeros")]
        [Display(Name = "Número")]
        public int Numero { get; set; }

        //[Required(ErrorMessage = "O complento não pode ser nulo", AllowEmptyStrings = false)]
        [MaxLength(15, ErrorMessage = "O campo complento deve ter no máximo (15) caracteres.")]
        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Required(ErrorMessage = "O bairro não pode ser nulo", AllowEmptyStrings = true)]
        [MinLength(  5, ErrorMessage = "O campo bairro deve ter ao menos (5) caracteres.")]
        [MaxLength(250, ErrorMessage = "O campo bairro deve ter no máximo (250) caracteres.")]
        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "A cidade não pode ser nula", AllowEmptyStrings = true)]
        [MinLength( 5, ErrorMessage = "O campo cidade deve ter ao menos (5) caracteres.")]
        [MaxLength(50, ErrorMessage = "O campo cidade deve ter no máximo (50) caracteres.")]
        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "A cidade não pode ser nula", AllowEmptyStrings = true)]
        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O cep não pode ser nula", AllowEmptyStrings = true)]
        [MinLength(8, ErrorMessage = "O campo cep deve ter ao menos (8) caracteres.")]
        [MaxLength(9, ErrorMessage = "O campo cep deve ter no máximo (9) caracteres.")]
        [Display(Name = "CEP")]
        public string Cep { get; set; }

        public string AnuncianteId { get; set; }
    }
}