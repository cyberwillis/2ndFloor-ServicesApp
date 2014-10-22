using System;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IConsumidorRepository : IRepository<Consumidor, Guid>
    {
        void InserirConsumidor(Consumidor consumidor);
    }
}