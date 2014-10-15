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
            Property(o => o.Id).HasColumnName("Id");//.IsOptional();
            Property(p => p.NomeProduto).HasColumnName("NomeProduto").HasMaxLength(250);
            Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(1000);
            Property(p => p.Referencia).HasColumnName("Referencia").HasMaxLength(15);
            Property(p => p.Fabricante).HasColumnName("Fabricante").HasMaxLength(250);
            Property(p => p.Valor).HasColumnName("Valor");

            //HasOptional(p => p.Anuncio).WithMany(a=>a.Ofertas)

            Ignore(o => o.BrokenRules);
            //Ignore(o => o.Anuncio);

            /*HasRequired(o => o.Endereco).WithRequiredPrincipal().Map(x => x
                .MapKey("OfertaId")
                .ToTable("tbEndereco")
                ).WillCascadeOnDelete(true);*/
        }
    }
}