using System;
using System.Data.Entity;
using SecondFloor.Model;
using SecondFloor.RepositoryEF.Mappings;

namespace SecondFloor.RepositoryEF
{
    public class AnuncianteContext : DbContext, IAnuncioContext 
    {
        public DbSet<Anunciante> Anunciantes { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Anuncio> Anuncios { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Oferta> Ofertas { get; set; }
        public DbSet<Estado> Estados { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }

        public AnuncianteContext() : base("DefaultConnection")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new AnuncianteConfiguration());
            modelBuilder.Configurations.Add(new EnderecoConfiguration());
            modelBuilder.Configurations.Add(new EstadoConfiguration());
            modelBuilder.Configurations.Add(new ProdutoConfiguration());
            modelBuilder.Configurations.Add(new AnuncioConfiguration());
            modelBuilder.Configurations.Add(new OfertaConfiguration());

            modelBuilder.Configurations.Add(new FeedbackConfiguration());

            modelBuilder.Ignore<Consumidor>(); //Usar em outro contexto
            modelBuilder.Ignore<Comentario>(); //Usar em outro contexto

            base.OnModelCreating(modelBuilder);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}