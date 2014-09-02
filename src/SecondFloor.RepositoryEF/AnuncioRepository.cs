using System.Data.Entity;
using SecondFloor.Infrastructure.Model;
using SecondFloor.Model;
using SecondFloor.RepositoryEF.Mappings;

namespace SecondFloor.RepositoryEF
{
    public class AnuncioRepository : DbContext
    {
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Anunciante> Anunciante { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public AnuncioRepository() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnuncioConfiguration());
            modelBuilder.Configurations.Add(new OfertaConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new AnuncianteConfiguration());

            modelBuilder.Ignore<BusinessRule>();
            modelBuilder.Ignore<Consumidor>(); //Usar em outro contexto
            modelBuilder.Ignore<Comentario>(); //Usar em outro contexto

            base.OnModelCreating(modelBuilder);
        }
    }
}