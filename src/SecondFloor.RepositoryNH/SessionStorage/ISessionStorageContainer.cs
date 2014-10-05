using NHibernate;

namespace SecondFloor.RepositoryNH.SessionStorage
{
    public interface ISessionStorageContainer
    {
        ISession GetCurrentSession();
        void Store(ISession session);
    }
}