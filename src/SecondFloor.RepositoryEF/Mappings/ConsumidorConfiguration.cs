using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class ConsumidorConfiguration : EntityTypeConfiguration<Consumidor>
    {
        public ConsumidorConfiguration()
        {
            ToTable("tbConsumidor");
            HasKey(c => c.Id);
            Property(c => c.Id).HasColumnName("Id");
            Property(c => c.Nome).HasMaxLength(50);
            Property(c => c.Email).HasMaxLength(250);
            //Property(c => c.TipoAcesso);
            Property(c => c.Token).HasMaxLength(100);

            Ignore(c => c.BrokenRules);
        }
    }
}