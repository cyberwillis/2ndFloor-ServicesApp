using SecondFloor.DataContracts.Messages.Usuario;

namespace SecondFloor.ServiceContracts
{
    public interface IUsuarioService
    {
        EncontrarUsuarioResponse EncontrarUsuarioPor(EncontrarUsuarioRequest request);

        CadastrarUsuarioResponse CadastrarUsuario(CadastrarUsuarioRequest request);

        GerarNovaSenhaResponse GerarNovaSenha(GerarNovaSenhaRequest request); 
    }
}