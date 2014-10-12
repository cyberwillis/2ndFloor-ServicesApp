using System.Collections.Generic;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IEstadoRepository : IRepository<Estado, int>
    {
        IList<Estado> EncontrarTodosEstados();
        Estado EncontrarEstadoPorSigla(string estadoSigla);
    }
}