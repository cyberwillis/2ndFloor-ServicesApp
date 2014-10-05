using System.Data.Entity.Migrations;

namespace SecondFloor.RepositoryEF.Migrations
{
    public class AnuncioModelConfiguration : DbMigrationsConfiguration<AnuncianteContext>
    {
        public AnuncioModelConfiguration()
        {
            AutomaticMigrationDataLossAllowed = true;
            AutomaticMigrationsEnabled = true;
        }
    }
}