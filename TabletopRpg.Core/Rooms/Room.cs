using System.Collections.Generic;
using TabletopRpg.Core.Communication;
using TabletopRpg.Core.Domain;

namespace TabletopRpg.Core.Rooms
{
    public class Room: Entity
    {
        public ChatRoom ChatRoom { get; set; }
        public ChatRoom RoleplayChatRoom { get; set; }
        
        public ICollection<RoomUserPermission> RoomUserPermissions { get; set; }
    }
}