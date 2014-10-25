using System;
using Microsoft.Practices.ObjectBuilder2;
using SecondFloor.DataContracts.DTO;
using SecondFloor.DataContracts.Messages.Usuario;
using SecondFloor.I18n;
using SecondFloor.Infrastructure;
using SecondFloor.Model;
using SecondFloor.Model.Rules;
using SecondFloor.Service.ExtensionMethods;
using SecondFloor.ServiceContracts;

namespace SecondFloor.Service
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }


        public EncontrarUsuarioResponse EncontrarUsuarioPor(EncontrarUsuarioRequest request)
        {
            var response = new EncontrarUsuarioResponse();

            var usuario = request.Usuario.ConvertToUsuario();
            if (!usuario.IsValid())
            {
                usuario.BrokenRules.ForEach(x => response.Rules.Add(x.Key, x.Value));

                response.Message = usuario.GetErrorMessages().ToString();
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                usuario = _usuarioRepository.EncontrarUsuarioPor(usuario.Login, usuario.Password);
                if (usuario == null)
                {
                    response.Message = Resources.UsuarioServices_EncontrarUsuarioPor_NotFound ;
                    response.MessageType = "alert-warning";
                    response.Success = false;
                    return response;
                }

                response.Message = Resources.UsuarioServices_EncontrarUsuarioPor_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Usuario = usuario.ConvertToUsuarioDto();
                
                //Fix para enviar email e senha em branco 
                response.Usuario.Login = ""; // nao me interessa mostrar o email do usuario!
                response.Usuario.Password = ""; //nao me interessa mostrar senha em hash!
            }
            catch (Exception ex)
            {
                response.Message = Resources.UsuarioServices_EncontrarUsuarioPor_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }
            return response;
        }

        public CadastrarUsuarioResponse CadastrarUsuario(CadastrarUsuarioRequest request)
        {
            var response = new CadastrarUsuarioResponse();

            var usuario = request.Usuario.ConvertToUsuario();
            if (!usuario.IsValid())
            {
                usuario.BrokenRules.ForEach(x => response.Rules.Add(x.Key, x.Value));

                response.Message = usuario.GetErrorMessages().ToString();
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                _usuarioRepository.CadastrarUsuario(usuario);
                _usuarioRepository.Persist();

                response.Message = Resources.UsuarioService_CadastrarUsuario_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Usuario = usuario.ConvertToUsuarioDto();
                
                //Fix para enviar email e senha em branco 
                response.Usuario.Login = ""; // nao me interessa mostrar o email do usuario!
                response.Usuario.Password = ""; //nao me interessa mostrar senha em hash!

            }
            catch (Exception ex)
            {
                response.Message = Resources.UsuarioService_CadastrarUsuario_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }
            return response;
        }

        public GerarNovaSenhaResponse GerarNovaSenha(GerarNovaSenhaRequest request)
        {
            var response = new GerarNovaSenhaResponse();

            var usuario = _usuarioRepository.EncontrarUsuarioPor(request.Usuario.Login);
            if (usuario == null)
            {
                response.Message = Resources.UsuarioService_GerarNovaSenha_NotFound;
                response.MessageType = "alert-warning";
                response.Success = false;
                return response;
            }

            try
            {
                var novoUsuario = request.Usuario.ConvertToUsuario();
                usuario.Password = novoUsuario.Password; //pega a senha nova em hash

                _usuarioRepository.AlterarUsuario(usuario);
                _usuarioRepository.Persist();

                response.Message = Resources.UsuarioService_GerarNovaSenha_Success;
                response.MessageType = "alert-info";
                response.Success = true;
                response.Usuario = usuario.ConvertToUsuarioDto();
            }
            catch (Exception ex)
            {
                response.Message = Resources.UsuarioService_GerarNovaSenha_Error + "\n" + ex.Message;
                response.MessageType = "alert-danger";
                response.Success = false;
            }

            return response;
        }
    }
}