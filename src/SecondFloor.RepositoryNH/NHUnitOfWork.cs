using System;
using NHibernate;
using SecondFloor.Infrastructure.Model;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.RepositoryNH
{
    public class NHUnitOfWork : IUnitOfWork
    {
        public NHUnitOfWork()
        {
        }

        public void SaveNew(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            SessionProvider.GetCurrentSession().Save(entity);
        }

        public void SaveAmended(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            SessionProvider.GetCurrentSession().SaveOrUpdate(entity);
        }

        public void SaveRemoved(IAggregateRoot entity, IUnitOfWorkRepository repository)
        {
            SessionProvider.GetCurrentSession().Delete(entity);
        }

        public void Commit()
        {
            using (ITransaction transaction = SessionProvider.GetCurrentSession().BeginTransaction())
            {
                try
                {
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}