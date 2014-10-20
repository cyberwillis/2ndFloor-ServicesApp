using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using SecondFloor.I18N;

namespace SecondFloor.Web.Mvc.Models
{
    public class EnderecoViewModels
    {
        #region ViewModel
        public string Id { get; set; }

        [Display(Name = "EnderecoViewModels_AttributeName_Logradouro", ResourceType = typeof(Resources))]
        public string Logradouro { get; set; }

        [Display(Name = "EnderecoViewModels_AttributeName_Numero", ResourceType = typeof(Resources))]
        public int Numero { get; set; }

        [Display(Name = "EnderecoViewModels_AttributeName_Complemento", ResourceType = typeof(Resources))]
        public string Complemento { get; set; }

        [Display(Name = "EnderecoViewModels_AttributeName_Bairro", ResourceType = typeof(Resources))]
        public string Bairro { get; set; }

        [Display(Name = "EnderecoViewModels_AttributeName_Cidade", ResourceType = typeof(Resources))]
        public string Cidade { get; set; }

        [Display(Name = "EnderecoViewModels_AttributeName_Estado", ResourceType = typeof(Resources))]
        public string Estado { get; set; }

        [Display(Name = "EnderecoViewModels_AttributeName_Cep", ResourceType = typeof(Resources))]
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

        private string _logradouroCompleto;
        public string LogradouroCompleto
        {
            get { return Logradouro + ", nº " + Numero + " - " + Bairro; }
            set { _logradouroCompleto = value; }
        }

        #endregion
    }
}