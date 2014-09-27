namespace SecondFloor.Infrastructure.Repository
{
    public interface IRepository
    {
        //TEntity FindBy(TId id);
        //IList<TEntity> FindAll(); 
        //void Insert(TEntity entity);
        //void Update(TEntity entity);
        //void Delete(TEntity entity);

        void Persist();
    }
}