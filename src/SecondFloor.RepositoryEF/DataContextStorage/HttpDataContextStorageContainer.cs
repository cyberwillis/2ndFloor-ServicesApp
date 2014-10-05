using System.Web;

namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public class HttpDataContextStorageContainer : IDataContextStorageContainer
    {
        private const string DataContextKey = "DataContext";

        public AnuncianteContext GetDataContext()
        {
            AnuncianteContext efContext = null;
            if (HttpContext.Current.Items.Contains(DataContextKey))
            {
                efContext = (AnuncianteContext)HttpContext.Current.Items[DataContextKey];
            }
            return efContext;
        }

        public void Store(AnuncianteContext anuncianteDataContext)
        {
            if (HttpContext.Current.Items.Contains(DataContextKey))
            {
                HttpContext.Current.Items[DataContextKey] = anuncianteDataContext;
            }
            else
            {
                HttpContext.Current.Items.Add(DataContextKey, anuncianteDataContext);
            }
        }
    }
}