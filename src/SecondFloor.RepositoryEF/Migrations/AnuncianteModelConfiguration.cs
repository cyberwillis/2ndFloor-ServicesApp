using System.Data.Entity;
using System.Data.Entity.Migrations;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Migrations
{
    public class AnuncianteModelConfiguration : CreateDatabaseIfNotExists<AnuncianteContext>
    {
        public AnuncianteModelConfiguration()
        {
            //AutomaticMigrationDataLossAllowed = true;
            //AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(AnuncianteContext context)
        {
            context.Estados.Add(new Estado() { Id = 1, Sigla = "AC", Nome = "Acre", });
            context.Estados.Add(new Estado() { Id = 2, Sigla = "AL", Nome = "Alagoas" });
            context.Estados.Add(new Estado() { Id = 3, Sigla = "AP", Nome = "Amapá" });
            context.Estados.Add(new Estado() { Id = 4, Sigla = "AM", Nome = "Amazonas" });
            context.Estados.Add(new Estado() { Id = 5, Sigla = "BA", Nome = "Bahia" });
            context.Estados.Add(new Estado() { Id = 6, Sigla = "CE", Nome = "Ceará" });
            context.Estados.Add(new Estado() { Id = 7, Sigla = "DF", Nome = "Distrito Federal" });
            context.Estados.Add(new Estado() { Id = 8, Sigla = "ES", Nome = "Espírito Santo" });
            context.Estados.Add(new Estado() { Id = 9, Sigla = "GO", Nome = "Goiás" });
            context.Estados.Add(new Estado() { Id = 10, Sigla = "MA", Nome = "Maranhão" });
            context.Estados.Add(new Estado() { Id = 11, Sigla = "MT", Nome = "Mato Grosso" });
            context.Estados.Add(new Estado() { Id = 12, Sigla = "MS", Nome = "Mato Grosso do Sul" });
            context.Estados.Add(new Estado() { Id = 13, Sigla = "MG", Nome = "Minas Gerais" });
            context.Estados.Add(new Estado() { Id = 14, Sigla = "PA", Nome = "Pará" });
            context.Estados.Add(new Estado() { Id = 15, Sigla = "PB", Nome = "Paraíba" });
            context.Estados.Add(new Estado() { Id = 16, Sigla = "PR", Nome = "Paraná" });
            context.Estados.Add(new Estado() { Id = 17, Sigla = "PE", Nome = "Pernambuco" });
            context.Estados.Add(new Estado() { Id = 18, Sigla = "PI", Nome = "Piauí" });
            context.Estados.Add(new Estado() { Id = 19, Sigla = "RJ", Nome = "Rio de Janeiro" });
            context.Estados.Add(new Estado() { Id = 20, Sigla = "RN", Nome = "Rio Grande do Norte" });
            context.Estados.Add(new Estado() { Id = 21, Sigla = "RS", Nome = "Rio Grande do Sul" });
            context.Estados.Add(new Estado() { Id = 22, Sigla = "RO", Nome = "Rondônia" });
            context.Estados.Add(new Estado() { Id = 23, Sigla = "RR", Nome = "Roraima" });
            context.Estados.Add(new Estado() { Id = 24, Sigla = "SC", Nome = "Santa Catarina" });
            context.Estados.Add(new Estado() { Id = 25, Sigla = "SP", Nome = "São Paulo" });
            context.Estados.Add(new Estado() { Id = 26, Sigla = "SE", Nome = "Sergipe" });
            context.Estados.Add(new Estado() { Id = 27, Sigla = "TO", Nome = "Tocantins" });

            base.Seed(context);
        }
    }
}