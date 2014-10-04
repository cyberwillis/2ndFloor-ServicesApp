using SecondFloor.RepositoryEF.DataContextStorage;

namespace SecondFloor.RepositoryEF
{
    public class AnuncioContextFactory
    {
        public static AnuncioContext GetDataContext()
        {
            IDataContextStorageContainer dataContextStorageContainer = DataContextStorageFactory.CreateStorageContainer();

            AnuncioContext anuncioContext = dataContextStorageContainer.GetDataContext();
            if (anuncioContext == null)
            {
                anuncioContext = new AnuncioContext();
                dataContextStorageContainer.Store(anuncioContext);
            }

            return anuncioContext;
        }
    }
}