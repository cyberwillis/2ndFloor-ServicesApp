using System.Collections.Generic;

namespace SecondFloor.Infrastructure.Repository
{
    public interface IRepository<TEntity,TId>
    {
        IList<TEntity> FindAll(); 
        TEntity FindBy(TId id);
        void Insert(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        void Persist();
    }
}