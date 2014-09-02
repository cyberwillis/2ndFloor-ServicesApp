using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class EnderecoConfiguration : EntityTypeConfiguration<Endereco>
    {
        public EnderecoConfiguration()
        {
            ToTable("tbEndereco");
            HasKey(e=>e.Id);
            Property(e => e.Logradouro).HasColumnName("Logradouro");
            Property(e => e.Numero).HasColumnName("Numero");
            Property(e => e.Complemento).HasColumnName("Complemento");
            Property(e => e.Bairro).HasColumnName("Bairro");
            Property(e => e.Cidade).HasColumnName("Cidade");
            Property(e => e.Estado).HasColumnName("Estado");

            Ignore(e => e.BrokenRules);
        }
    }
}