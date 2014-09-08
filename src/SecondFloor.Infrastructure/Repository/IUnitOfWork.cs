using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        void SaveNew(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void SaveAmended(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void SaveRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository);
        void Commit(); 
    }
}