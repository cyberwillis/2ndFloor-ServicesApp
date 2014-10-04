using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Infrastructure.Repository
{
    public interface IUnitOfWork
    {
        void SaveNew(IAggregateRoot entity);
        void SaveAmended(IAggregateRoot entity);
        void SaveRemoved(IAggregateRoot entity);
        void Commit(); 
    }
}