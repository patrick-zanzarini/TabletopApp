using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopRpg.Core.Communication;

namespace TabletopRpg.DataAccess.Mapping
{
    public class ChatMessageMapping: EntityTypeConfiguration<ChatMessage>
    {
        public override void Configure(EntityTypeBuilder<ChatMessage> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Message)
                .HasMaxLength(2000)
                .IsRequired();
            
            builder.Property(x => x.DisplayName)
                .HasMaxLength(50)
                .IsRequired();

            builder.HasOne(x => x.User)
                .WithOne()
                .HasForeignKey<ChatMessage>(x => x.UserId);
        }
    }
}