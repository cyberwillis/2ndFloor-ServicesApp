using System.Data.Entity.Migrations;

namespace SecondFloor.RepositoryEF.Migrations
{
    public class AnuncioModelConfiguration : DbMigrationsConfiguration<AnuncioContext>
    {
        public AnuncioModelConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}