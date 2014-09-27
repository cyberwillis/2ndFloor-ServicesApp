using System.Data.Entity;
using SecondFloor.Model;
using SecondFloor.RepositoryEF.Mappings;

namespace SecondFloor.RepositoryEF
{
    public class AnuncioContext : DbContext
    {
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Anunciante> Anunciantes { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }

        public AnuncioContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnuncioConfiguration());
            modelBuilder.Configurations.Add(new OfertaConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new AnuncianteConfiguration());

            modelBuilder.Ignore<Consumidor>(); //Usar em outro contexto
            modelBuilder.Ignore<Comentario>(); //Usar em outro contexto

            base.OnModelCreating(modelBuilder);
        }
    }
}