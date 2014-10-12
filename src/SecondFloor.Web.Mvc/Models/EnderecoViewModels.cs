using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace SecondFloor.Web.Mvc.Models
{
    public class EnderecoViewModels
    {
        #region ViewModel
        public string Id { get; set; }

        [Display(Name = "Logradouro")]
        public string Logradouro { get; set; }

        [Display(Name = "Número")]
        public int Numero { get; set; }

        [Display(Name = "Complemento")]
        public string Complemento { get; set; }

        [Display(Name = "Bairro")]
        public string Bairro { get; set; }

        [Display(Name = "Cidade")]
        public string Cidade { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "CEP")]
        public string Cep { get; set; }
        #endregion

        #region Helpers Attributes
        public IList<EstadoViewModel> Estados { get; set; }

        public string AnuncianteId { get; set; }
        #endregion

        #region Helpers Methods
        public SelectList GetEstadosSelectList()
        {
            var list = new List<EstadoViewModel>();
            list.Add(new EstadoViewModel() { Sigla = "", Nome = "Selecione" });

            if (Estados != null)
            {
                list.AddRange(Estados);
                //return new SelectList(Estados, "Id", "Nome");
            }
            return new SelectList(list, "Sigla", "Nome");
        }
        #endregion
    }
}