using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.Model
{
    public interface IAnuncianteRepository<TEntity,TId> : IRepository<TEntity,TId>
    {
        TEntity GetByToken(string anuncianteToken);
    }
}