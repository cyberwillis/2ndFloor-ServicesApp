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
            Property(a => a.RazaoSocial);
            Property(a => a.Cnpj);
            Property(a => a.Pontuacao);
            Property(a => a.Token);

            HasMany(a => a.Anuncios);
        }
    }
}