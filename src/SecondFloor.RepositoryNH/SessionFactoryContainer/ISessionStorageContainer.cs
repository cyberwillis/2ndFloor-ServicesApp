using NHibernate;

namespace SecondFloor.RepositoryNH.SessionFactoryContainer
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}