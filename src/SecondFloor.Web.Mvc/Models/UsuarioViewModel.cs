using System.ComponentModel.DataAnnotations;
using SecondFloor.I18n;

namespace SecondFloor.Web.Mvc.Models
{
    public class UsuarioViewModel
    {
        [Display(Name = "UsuarioViewModels_Attribute_Email", ResourceType = typeof(Resources))]
        public string Email { get; set; }

        [Display(Name = "UsuarioViewModels_Attribute_Senha", ResourceType = typeof(Resources))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "UsuarioViewModels_Attribute_Lembrar", ResourceType = typeof(Resources))]
        public bool RememberMe { get; set; }
    }


    //public class LoginViewModel
    //{
    //    [Required]
    //    [Display(Name = "Email")]
    //    [EmailAddress]
        

    //    [Required]
    //    [DataType(DataType.Password)]
    //    [Display(Name = "Password")]
        

    //    [Display(Name = "Remember me?")]
        
    //}
}