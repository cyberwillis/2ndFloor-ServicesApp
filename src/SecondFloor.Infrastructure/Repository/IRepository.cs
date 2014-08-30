using System.Collections.Generic;

namespace SecondFloor.Infrastructure.Repository
{
    public interface IRepository<TEntity, TId>
    {
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Persist();

        TEntity FindBy(TId id);
        IList<TEntity> FindAll(); 
    }
}