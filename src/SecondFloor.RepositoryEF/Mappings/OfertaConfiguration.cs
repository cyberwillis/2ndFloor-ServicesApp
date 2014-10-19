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
            Property(p => p.NomeProduto).HasColumnName("NomeProduto").HasMaxLength(250);
            Property(p => p.Referencia).HasColumnName("Referencia").HasMaxLength(15);
            Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(1000);
            Property(p => p.Fabricante).HasColumnName("Fabricante").HasMaxLength(250);
            Property(p => p.Valor).HasColumnName("Valor");

            Property(e => e.Logradouro).HasColumnName("Logradouro").HasMaxLength(250);
            Property(e => e.Numero).HasColumnName("Numero").HasMaxLength(5);
            Property(e => e.Complemento).HasColumnName("Complemento").HasMaxLength(250);
            Property(e => e.Bairro).HasColumnName("Bairro").HasMaxLength(50);
            Property(e => e.Cidade).HasColumnName("Cidade").HasMaxLength(50);
            Property(e => e.Cep).HasColumnName("Cep").HasMaxLength(10);
            Property(e => e.Estado).HasColumnName("Estado").HasMaxLength(10);

            Ignore(o => o.BrokenRules);

            
        }
    }
}