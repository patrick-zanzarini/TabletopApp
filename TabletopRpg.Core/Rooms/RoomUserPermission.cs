using TabletopRpg.Core.Domain;

namespace TabletopRpg.Core.Rooms
{
    public class RoomUserPermission: Entity
    {
        public Room Room { get; set; }
        public User User { get; set; }

        public RoomUserAccessPermission AccessPermission { get; set; }
    }
}