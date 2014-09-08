using SecondFloor.Infrastructure.Model;

namespace SecondFloor.Infrastructure.Repository
{
    public interface IUnitOfWorkRepository
    {
        void PersistCreatedOf(IAggregateRoot entity);
        void PersistUpdatedOf(IAggregateRoot entity);
        void PersistDeletedOf(IAggregateRoot entity);
    }
}