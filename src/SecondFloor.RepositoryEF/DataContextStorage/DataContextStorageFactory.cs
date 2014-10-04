using System.Web;

namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public class DataContextStorageFactory
    {
        private static IDataContextStorageContainer _dataContextStorageContainer;

        public static IDataContextStorageContainer CreateStorageContainer()
        {
            if (_dataContextStorageContainer == null)
            {
                if (HttpContext.Current == null)
                    _dataContextStorageContainer = new ThreadDataContextStorageContainer();
                else
                    _dataContextStorageContainer = new HttpDataContextStorageContainer();
            }

            return _dataContextStorageContainer;
        }
    }
}