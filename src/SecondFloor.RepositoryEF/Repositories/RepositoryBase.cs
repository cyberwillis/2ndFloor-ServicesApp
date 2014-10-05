using System.Collections.Generic;
using System.Linq;
using SecondFloor.Infrastructure.Model;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.RepositoryEF.Repositories
{
    public class RepositoryBase<TEntity, TId> : IRepository<TEntity, TId> where TEntity : class, IAggregateRoot
    {
        private readonly IUnitOfWork _unitOfWork;

        public RepositoryBase(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IList<TEntity> FindAll()
        {
            return AnuncianteContextFactory.GetAnuncianteContext().Set<TEntity>().ToList();
        }

        public TEntity FindBy(TId id)
        {
            return AnuncianteContextFactory.GetAnuncianteContext().Set<TEntity>().Find(id);
        }

        public void Insert(TEntity entity)
        {
            _unitOfWork.SaveNew(entity);
        }

        public void Update(TEntity entity)
        {
            _unitOfWork.SaveAmended(entity);
        }

        public void Delete(TEntity entity)
        {
            _unitOfWork.SaveRemoved(entity);
        }

        public void Persist()
        {
            _unitOfWork.Commit();
        }
    }
}