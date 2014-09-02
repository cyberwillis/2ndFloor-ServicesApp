using System.Data.Entity.Migrations;

namespace SecondFloor.RepositoryEF.Migrations
{
    public class AnuncioModelConfiguration : DbMigrationsConfiguration<AnuncioRepository>
    {
        public AnuncioModelConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}