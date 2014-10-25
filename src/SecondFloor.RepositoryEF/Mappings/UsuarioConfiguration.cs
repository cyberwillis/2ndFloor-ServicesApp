using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class UsuarioConfiguration : EntityTypeConfiguration<Usuario>
    {
        public UsuarioConfiguration()
        {
            ToTable("tbUsuario");
            HasKey(u => u.Id);
            Property(u => u.Id).HasColumnName("Id");
            Property(u => u.Login).HasMaxLength(250);
            Property(u => u.Password).HasMaxLength(40);
        }
    }
}