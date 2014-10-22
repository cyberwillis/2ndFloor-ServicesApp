using System;
using SecondFloor.Infrastructure.Repository;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class ConsumidorRepository : RepositoryBase<Consumidor, Guid>, IConsumidorRepository
    {
        public ConsumidorRepository(EFUnitOfWork<Consumidor> unitOfWork)
            : base(unitOfWork)
        {
        }

        public void InserirConsumidor(Consumidor consumidor)
        {
            this.Insert(consumidor);
        }
    }
}