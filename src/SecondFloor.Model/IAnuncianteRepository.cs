using System;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncianteRepository : IRepository<Anunciante,Guid>
    {
        Anunciante GetByToken(string anuncianteToken);
    }
}