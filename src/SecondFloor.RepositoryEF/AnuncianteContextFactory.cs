using SecondFloor.RepositoryEF.DataContextStorage;

namespace SecondFloor.RepositoryEF
{
    public class AnuncianteContextFactory
    {
        public static AnuncianteContext GetAnuncianteContext()
        {
            IDataContextStorageContainer dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();

            AnuncianteContext anuncianteContext = dataContextStorageContainer.GetDataContext();
            if (anuncianteContext == null)
            {
                anuncianteContext = new AnuncianteContext();
                dataContextStorageContainer.Store(anuncianteContext);
            }

            return anuncianteContext;
        }
    }
}