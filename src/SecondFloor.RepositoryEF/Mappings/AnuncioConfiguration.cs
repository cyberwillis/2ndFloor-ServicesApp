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
            Property(a => a.Titulo).HasColumnName("Titulo");
            Property(a => a.DataInicio).HasColumnName("DataInicio");
            Property(a => a.DataFim).HasColumnName("DataFim");

            Ignore(a => a.BrokenRules);

            //Ignore(a => a.Anunciante);
            //HasRequired(a => a.Anunciante).WithMany().Map(x=>x.MapKey("AnuncianteId").ToTable("tbAnuncio"));
            //HasRequired(a=>a.Anunciante).WithMany(a=>a.Anuncios).Map(x => x.MapKey("AnuncianteId").ToTable("tbAnuncio"));

            HasMany(a => a.Ofertas).WithOptional().Map(x=>x
                .MapKey("AnuncioId")
                .ToTable("tbOferta")
                ).WillCascadeOnDelete(true);
        }
    }
}