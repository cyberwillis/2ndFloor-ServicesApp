using System.Data.Entity;
using SecondFloor.Infrastructure.Model;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.RepositoryEF
{
    public class EFUnitOfWork<TEntity> : IUnitOfWork where TEntity : class, IAggregateRoot
    {
        public void SaveNew(IAggregateRoot entity)
        {
            AnuncianteContextFactory.GetAnuncianteContext().Set<TEntity>().Add((TEntity)entity);
        }

        public void SaveAmended(IAggregateRoot entity)
        {
            AnuncianteContextFactory.GetAnuncianteContext().Entry(entity).State = EntityState.Modified;
        }

        public void SaveRemoved(IAggregateRoot entity)
        {
            AnuncianteContextFactory.GetAnuncianteContext().Set<TEntity>().Remove((TEntity)entity);
        }

        public void Commit()
        {
            AnuncianteContextFactory.GetAnuncianteContext().SaveChanges();
            AnuncianteContextFactory.GetAnuncianteContext().Configuration.ValidateOnSaveEnabled = true;
        }
    }
}