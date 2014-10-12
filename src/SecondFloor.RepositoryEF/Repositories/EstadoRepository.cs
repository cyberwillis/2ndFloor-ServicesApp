using System.Collections.Generic;
using System.Linq;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class EstadoRepository : RepositoryBase<Estado, int>, IEstadoRepository
    {
        public EstadoRepository(EFUnitOfWork<Estado> unitOfWork) : base(unitOfWork)
        {
        }

        public IList<Estado> EncontrarTodosEstados()
        {
            return this.FindAll();
        }

        public Estado EncontrarEstadoPorSigla(string estadoSigla)
        {
            var estado = from e in AnuncianteContextFactory.GetAnuncianteContext().Estados
                         where e.Sigla == estadoSigla
                         select e;

            return estado.SingleOrDefault();
        }
    }
}