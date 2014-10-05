namespace SecondFloor.RepositoryEF.DataContextStorage
{
    public interface IDataContextStorageContainer
    {
        AnuncianteContext GetDataContext();
        void Store(AnuncianteContext anuncianteDataContext); 
    }
}