using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class ProdutoConfiguration :EntityTypeConfiguration<Produto>
    {
        public ProdutoConfiguration()
        {
            ToTable("tbProduto");
            HasKey(p => p.Id);
            Property(p => p.Id).HasColumnName("Id");
            Property(p => p.NomeProduto).HasColumnName("NomeProduto").HasMaxLength(250);
            Property(p => p.Descricao).HasColumnName("Descricao").HasMaxLength(1000);
            Property(p => p.Referencia).HasColumnName("Referencia").HasMaxLength(15);
            Property(p => p.Fabricante).HasColumnName("Fabricante").HasMaxLength(250);
            Property(p => p.Valor).HasColumnName("Valor");

            Ignore(p => p.BrokenRules);
        }
    }
}