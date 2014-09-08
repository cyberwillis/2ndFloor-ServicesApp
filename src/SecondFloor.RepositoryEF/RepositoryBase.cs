using System.Data.Entity;
using SecondFloor.Infrastructure.Repository;

namespace SecondFloor.RepositoryEF
{
    public class RepositoryBase : IRepository
    {
        protected DbContext _context;
        public DbContext Context { get { return _context; } }

        public void Persist()
        {
            Context.SaveChanges();
        }
    }
}