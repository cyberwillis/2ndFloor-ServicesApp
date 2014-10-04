namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        AnuncioContext GetDataContext();
        void Store(AnuncioContext anuncioDataContext); 
    }
}