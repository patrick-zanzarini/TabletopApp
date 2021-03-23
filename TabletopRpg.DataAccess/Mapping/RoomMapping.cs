using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopRpg.Core.Rooms;

namespace TabletopRpg.DataAccess.Mapping
{
    public class RoomMapping : EntityTypeConfiguration<Room>
    {
        public override void Configure(EntityTypeBuilder<Room> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.ChatRoom)
                .WithOne(x => x.Room);
            
            builder.HasOne(x => x.RoleplayChatRoom)
                .WithOne(x => x.Room);

            builder.HasMany(x => x.RoomUserPermissions)
                .WithOne(x => x.Room);
        }
    }
}