using System.Web;

namespace SecondFloor.RepositoryNH.SessionStorage
{
    public class SessionStorageFactory
    {
        private static ISessionStorageContainer _sessionStorageContainer;

        public static ISessionStorageContainer GetStorageContainer()
        {
            if (_sessionStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _sessionStorageContainer = new ThreadSessionStorageContainer();
                else
                    _sessionStorageContainer = new HttpSessionStorageContainer();
            }

            return _sessionStorageContainer;
        }
    }
}