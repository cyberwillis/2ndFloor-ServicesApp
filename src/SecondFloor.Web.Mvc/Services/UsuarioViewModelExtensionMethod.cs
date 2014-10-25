using SecondFloor.DataContracts.DTO;
using SecondFloor.Web.Mvc.Models;

namespace SecondFloor.Web.Mvc.Services
{
    public static class UsuarioViewModelExtensionMethod
    {
        public static UsuarioDto ConvertToUsuarioDto(this UsuarioViewModel usuarioView)
        {
            var usuarioDto = new UsuarioDto();
            usuarioDto.Login = usuarioView.Email;
            usuarioDto.Password = usuarioView.Password;

            return usuarioDto;
        }
    }
}