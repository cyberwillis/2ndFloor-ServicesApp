using System.ComponentModel.DataAnnotations;

namespace SecondFloor.Web.Mvc.Models
{
    public class ProdutoViewModels
    {
        public string Id { get; set; }

        //[Required(ErrorMessage = "O campo nome de produto/serviço não pode ser nulo")]
        //[MinLength(4, ErrorMessage = "O campo nome de produto/serviço deve ter ao menos (4) caracteres")]
        //[MaxLength(250, ErrorMessage = "O campo nome de produto/serviço deve ter no máximo (250) caracteres")]
        [Display(Name = "Produto / Serviço")]
        public string NomeProduto { get; set; }

        //[Required(ErrorMessage = "O campo descrição não pode ser nulo")]
        //[MinLength(   4, ErrorMessage = "O campo descrição deve ter ao menos (4) caracteres")]
        //[MaxLength(1000, ErrorMessage = "O campo descrição deve ter no máximo (1000) caracteres")]
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        //[MinLength( 1,ErrorMessage = "O campo de referencia de produto deve ter ao menos (1) caracter")]
        //[MaxLength(10, ErrorMessage = "O campo de referencia de produto deve ter no máximo (10) caracteres")]
        [Display(Name = "Referência")]
        public string RefProduto { get; set; }

        //[MinLength( 5, ErrorMessage = "O campo fabricante deve ter ao menos (5) caracteres")]
        //[MaxLength(250,ErrorMessage = "O campo fabricante deve ter no máximo (250) caracteres")]
        [Display(Name = "Fabricante")]
        public string Fabricante { get; set; }


        [Display(Name = "Valor")]
        public string Valor { get; set; }

        public string AnuncianteId { get; set; }

        //TODO: terminar as mensagens de erro
    }
}