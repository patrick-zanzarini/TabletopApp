using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TabletopRpg.Core.Rooms;

namespace TabletopRpg.DataAccess.Mapping
{
    public class RoomUserPermissionMapping: EntityTypeConfiguration<RoomUserPermission>
    {
        public override void Configure(EntityTypeBuilder<RoomUserPermission> builder)
        {
            base.Configure(builder);

            builder.HasOne(x => x.Room)
                .WithMany(x => x.UserPermissions);

            builder.HasOne(x => x.User)
                .WithMany(x => x.RoomUserPermissions);
        }
    }
}