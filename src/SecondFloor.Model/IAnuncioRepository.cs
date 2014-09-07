using System;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncioRepository : IRepository<Anuncio,Guid>
    {
         
    }
}