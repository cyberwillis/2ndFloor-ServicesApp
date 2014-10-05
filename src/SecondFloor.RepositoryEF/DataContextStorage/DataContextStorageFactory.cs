using System.Web;

namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public class DataContextStorageFactory
    {
        private static IDataContextStorageContainer _contextStorageContainer;

        public static IDataContextStorageContainer CreateStorageContainer()
        {
            if (_contextStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _contextStorageContainer = new ThreadDataContextStorageContainer();
                else
                    _contextStorageContainer = new HttpDataContextStorageContainer();
            }

            return _contextStorageContainer;
        }
    }
}