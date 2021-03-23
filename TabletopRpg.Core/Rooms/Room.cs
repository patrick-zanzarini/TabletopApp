using System;
using System.Collections.Generic;
using TabletopRpg.Core.Communication;
using TabletopRpg.Core.Domain;

namespace TabletopRpg.Core.Rooms
{
    public class Room: Entity
    {
        public Guid RoleplayChatId { get; set; }
        public ChatRoom RoleplayChat { get; set; }
        public ICollection<RoomUserPermission> UserPermissions { get; set; }
    }
}