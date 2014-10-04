using System.Data.Entity;
using SecondFloor.Infrastructure.Model;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.RepositoryEF
{
    public class EFUnitOfWork<TEntity> : IUnitOfWork where TEntity : class, IAggregateRoot
    {
        public void SaveNew(IAggregateRoot entity)
        {
            AnuncioContextFactory.GetDataContext().Set<TEntity>().Add((TEntity)entity);
        }

        public void SaveAmended(IAggregateRoot entity)
        {
            AnuncioContextFactory.GetDataContext().Entry(entity).State = EntityState.Modified;
        }

        public void SaveRemoved(IAggregateRoot entity)
        {
            AnuncioContextFactory.GetDataContext().Set<TEntity>().Remove((TEntity)entity);
        }

        public void Commit()
        {
            AnuncioContextFactory.GetDataContext().SaveChanges();
            AnuncioContextFactory.GetDataContext().Configuration.ValidateOnSaveEnabled = true;
        }
    }
}