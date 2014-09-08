using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class OfertaConfiguration : EntityTypeConfiguration<Oferta>
    {
        public OfertaConfiguration()
        {
            ToTable("tbOferta");
            HasKey(o => o.Id);
            Property(o => o.Id).HasColumnName("Id");
            Property(o => o.Titulo).HasColumnName("Titulo");
            Property(o => o.Descricao).HasColumnName("Descricao");
            Property(o => o.Preco).HasColumnName("Preco");

            Ignore(o => o.BrokenRules);

            HasRequired(o => o.Endereco).WithRequiredPrincipal().Map(x => x
                .MapKey("OfertaId")
                .ToTable("tbEndereco")
                ).WillCascadeOnDelete(true);
        }
    }
}