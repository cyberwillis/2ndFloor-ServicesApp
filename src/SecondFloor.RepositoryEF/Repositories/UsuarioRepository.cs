using System;
using System.Linq;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class UsuarioRepository : RepositoryBase<Usuario,Guid>, IUsuarioRepository
    {
        public UsuarioRepository(EFUnitOfWork<Usuario> unitOfWork) : base(unitOfWork)
        {
        }

        public Usuario EncontrarUsuarioPor(string login, string password)
        {
            var usuario = from u in AnuncianteContextFactory.GetAnuncianteContext().Set<Usuario>()
                where u.Login == login && u.Password == password
                select u;

            return usuario.SingleOrDefault();
        }

        public Usuario EncontrarUsuarioPor(string login)
        {
            var usuario = from u in AnuncianteContextFactory.GetAnuncianteContext().Set<Usuario>()
                          where u.Login == login 
                          select u;

            return usuario.SingleOrDefault();
        }

        public void CadastrarUsuario(Usuario usuario)
        {
            this.Insert(usuario);
        }

        public void AlterarUsuario(Usuario usuario)
        {
            this.Update(usuario);
        }
    }
}