using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SecondFloor.WebUIMVC.Models
{
    public class AnuncianteViewModels
    {
        public string Id { get; set; }

        [Required(ErrorMessage = "O campo Nome responsavel não pode ser nulo.",AllowEmptyStrings = false)]
        [MinLength(2,ErrorMessage = "O campo nome reponsavel deve ter ao menos 2 caracteres")]
        [MaxLength(250,ErrorMessage = "O campo nome responsavel nao pode possuir mais de 250 caracteres")]
        [Display(Name = "Nome do Responsável")]
        public string NomeResponsavel { get; set; }

        [Required(ErrorMessage = "Email não pode ser nulo.",AllowEmptyStrings = false)]
        [MinLength(10, ErrorMessage = "O campo e-mail  deve ter ao menos 10 caracteres")]
        [MaxLength(250, ErrorMessage = "O campo e-mail nao pode possuir mais de 250 caracteres")]
        [Display(Name = "E-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A RazaoSocial nao pode ser nula.",AllowEmptyStrings = false)]
        [MinLength(10, ErrorMessage = "O campo razao social  deve ter ao menos 10 caracteres")]
        [MaxLength(ErrorMessage = "O campo razao social nao pode possuir mais de 250 caracteres")]
        [Display(Name = "Razão Social")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "O Cnpj não pode ser nulo.", AllowEmptyStrings = false)]
        [MinLength(14, ErrorMessage = "O campo Cnpj deve ter ao menos 14 caracteres")]
        [MaxLength(18, ErrorMessage = "O campo Cnpj não pode possuir mais de 18 caracteres")]
        [Display(Name = "CNPJ")]
        public string Cnpj { get; set; }

        public ICollection<EnderecoViewModels> Enderecos { get; set; }
    }
}