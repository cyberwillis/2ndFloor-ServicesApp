using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class AnuncioConfiguration : EntityTypeConfiguration<Anuncio>
    {
        public AnuncioConfiguration()
        {
            ToTable("tbAnuncio");
            HasKey(a => a.Id);
            Property(a => a.Id).HasColumnName("Id");
            Property(a => a.Titulo).HasColumnName("Titulo").HasMaxLength(50);
            Property(a => a.DataInicio).HasColumnName("DataInicio");
            Property(a => a.DataFim).HasColumnName("DataFim");

            //Endereco da oferta
            Property(e => e.Logradouro).HasColumnName("Logradouro").HasMaxLength(250);
            Property(e => e.Numero).HasColumnName("Numero").HasMaxLength(5);
            Property(e => e.Complemento).HasColumnName("Complemento").HasMaxLength(250);
            Property(e => e.Bairro).HasColumnName("Bairro").HasMaxLength(50);
            Property(e => e.Cidade).HasColumnName("Cidade").HasMaxLength(50);
            Property(e => e.Cep).HasColumnName("Cep").HasMaxLength(10);
            Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(10);

            Ignore(a => a.BrokenRules);

            HasMany(a => a.Ofertas).WithRequired(o=>o.Anuncio)
                .Map(x=>x.MapKey("AnuncioId").ToTable("tbOferta"));

            /*HasMany(o => o.Ofertas).WithMany().Map(x => x
                    .MapLeftKey("AnuncioId")
                    .ToTable("tbAnuncio_tbOferta")
                    .MapRightKey("OfertaId"));*/
            
        }
    }
}