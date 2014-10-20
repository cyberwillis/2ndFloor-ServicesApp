using System.ComponentModel.DataAnnotations;
using SecondFloor.I18N;

namespace SecondFloor.Web.Mvc.Models
{
    public class ProdutoViewModels
    {
        public string Id { get; set; }

        [Display(Name = "ProdutoViewModels_AttributeName_NomeProduto", ResourceType = typeof(Resources))]
        public string NomeProduto { get; set; }

        [Display(Name = "ProdutoViewModels_AttributeName_Descricao", ResourceType = typeof(Resources))]
        public string Descricao { get; set; }

        [Display(Name = "ProdutoViewModels_AttributeName_Referencia", ResourceType = typeof(Resources))]
        public string Referencia { get; set; }

        [Display(Name = "ProdutoViewModels_AttributeName_Fabricante", ResourceType = typeof(Resources))]
        public string Fabricante { get; set; }

        [Display(Name = "ProdutoViewModels_AttributeName_Valor", ResourceType = typeof(Resources))]
        public string Valor { get; set; }

        public string AnuncianteId { get; set; }

        //TODO: terminar as mensagens de erro
    }
}