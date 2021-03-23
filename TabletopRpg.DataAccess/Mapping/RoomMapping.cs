using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopRpg.Core.Rooms;

namespace TabletopRpg.DataAccess.Mapping
{
    public class RoomMapping : EntityTypeConfiguration<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.RoleplayChat)
                .WithOne(x => x.Room)
                .HasForeignKey<Room>(b => b.RoleplayChatId);

            builder.HasMany(x => x.UserPermissions)
                .WithOne(x => x.Room);
        }
    }
}