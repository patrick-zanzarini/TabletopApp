using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopRpg.Core.Domain;

namespace TabletopRpg.DataAccess.Mapping
{
    public class UserMapping : EntityTypeConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);
            
            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Username)
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(x => x.Password)
                .HasMaxLength(50)
                .IsRequired();
        }
    }
}