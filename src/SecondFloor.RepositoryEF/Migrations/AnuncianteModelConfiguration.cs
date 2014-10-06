using System.Data.Entity;
using System.Data.Entity.Migrations;

namespace SecondFloor.RepositoryEF.Migrations
{
    public class AnuncianteModelConfiguration : DbMigrationsConfiguration<AnuncianteContext>
    {
        public AnuncianteModelConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}