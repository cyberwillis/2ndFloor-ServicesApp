using System.Web;

namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private const string DataContextKey = "DataContext";

        public AnuncioContext GetDataContext()
        {
            AnuncioContext efContext = null;
            if (HttpContext.Current.Items.Contains(DataContextKey))
            {
                efContext = (AnuncioContext)HttpContext.Current.Items[DataContextKey];
            }
            return efContext;
        }

        public void Store(AnuncioContext anuncioDataContext)
        {
            if (HttpContext.Current.Items.Contains(DataContextKey))
            {
                HttpContext.Current.Items[DataContextKey] = anuncioDataContext;
            }
            else
            {
                HttpContext.Current.Items.Add(DataContextKey, anuncioDataContext);
            }
        }
    }
}