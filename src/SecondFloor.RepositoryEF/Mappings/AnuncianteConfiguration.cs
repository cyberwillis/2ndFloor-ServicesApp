using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class AnuncianteConfiguration : EntityTypeConfiguration<Anunciante>
    {
        public AnuncianteConfiguration()
        {
            ToTable("tbAnunciante");
            HasKey(a => a.Id);
            Property(a => a.Id).HasColumnName("Id");
            Property(a => a.Responsavel).HasMaxLength(250);
            Property(a => a.Email).HasMaxLength(250);
            Property(a => a.RazaoSocial).HasMaxLength(250);
            Property(a => a.Cnpj).HasMaxLength(20);
            Property(a => a.Pontuacao);
            //Property(a => a.Token);

            Ignore(a => a.BrokenRules);

            HasMany(a => a.Anuncios).WithOptional(a=>a.Anunciante)
                .Map(x => x.MapKey("AnuncianteId").ToTable("tbAnuncio")).WillCascadeOnDelete(false);

            HasMany(a => a.Enderecos).WithOptional(a => a.Anunciante)
                .Map(x => x.MapKey("AnuncianteId").ToTable("tbEndereco")).WillCascadeOnDelete(false);
        }
    }
}