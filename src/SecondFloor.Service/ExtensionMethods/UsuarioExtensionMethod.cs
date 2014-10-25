using System;
using SecondFloor.DataContracts.DTO;
using SecondFloor.Infrastructure;
using SecondFloor.Model;

namespace SecondFloor.Service.ExtensionMethods
{
    public static class UsuarioExtensionMethod
    {
        public static UsuarioDto ConvertToUsuarioDto( this Usuario usuario)
        {
            var usuarioDto = new UsuarioDto();
            usuarioDto.Id = usuario.Id.ToString();
            usuarioDto.Login = usuario.Login;
            usuarioDto.Password = usuario.Password;

            return usuarioDto;
        }

        public static Usuario ConvertToUsuario(this UsuarioDto usuarioDto)
        {
            var usuario = new Usuario();
            
            if (!string.IsNullOrEmpty(usuarioDto.Id))
                usuario.Id = Guid.Parse(usuarioDto.Id);

            usuario.Login = usuarioDto.Login;
            usuario.Password = Sha1Util.SHA1HashStringForUTF8String(usuarioDto.Password);

            return usuario;
        }
    }
}