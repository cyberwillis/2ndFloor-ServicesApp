using System.Collections;
using System.Threading;
using NHibernate;

namespace SecondFloor.RepositoryNH.SessionFactoryContainer
{
    public class ThreadSessionStorageContainer : ISessionStorageContainer
    {
        private static readonly Hashtable NhSessions = new Hashtable();

        public ISession GetCurrentSession()
        {
            ISession nhSession = null;

            if (NhSessions.Contains(GetThreadName()))
                nhSession = (ISession)NhSessions[GetThreadName()];

            return nhSession;
        }

        public void Store(ISession session)
        {
            var threadName = GetThreadName();

            if (NhSessions.Contains(threadName))
                NhSessions[threadName] = session;
            else
                NhSessions.Add(threadName, session);
        }

        private string GetThreadName()
        {
            return Thread.CurrentThread.Name;
        }
    }
}