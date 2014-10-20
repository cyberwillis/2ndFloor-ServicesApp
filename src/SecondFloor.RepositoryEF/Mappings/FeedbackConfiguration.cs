using System.Data.Entity.ModelConfiguration;
using SecondFloor.Model;

namespace SecondFloor.RepositoryEF.Mappings
{
    public class FeedbackConfiguration : EntityTypeConfiguration<Feedback>
    {
        public FeedbackConfiguration()
        {
            ToTable("tbFeedback");
            HasKey(f => f.Id);
            Property(f => f.Id).HasColumnName("Id");
            Property(f => f.Nota);
            Property(f => f.Produto).HasMaxLength(40);
            Property(f => f.Consumidor).HasMaxLength(40);

            Ignore(f => f.BrokenRules);
        }
    }
}