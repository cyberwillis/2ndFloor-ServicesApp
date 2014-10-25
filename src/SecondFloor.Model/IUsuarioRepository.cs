using System;
using SecondFloor.DataContracts.Messages.Usuario;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IUsuarioRepository : IRepository<Usuario, Guid>
    {
        Usuario EncontrarUsuarioPor(string login, string password);
        Usuario EncontrarUsuarioPor(string login);
        void CadastrarUsuario(Usuario usuario);
        void AlterarUsuario(Usuario usuario);
    }
}