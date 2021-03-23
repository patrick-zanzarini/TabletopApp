using System.Collections.Generic;
using TabletopRpg.Core.Rooms;

namespace TabletopRpg.Core.Domain
{
    public class User: Entity
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        
        public ICollection<RoomUserPermission> RoomUserPermissions { get; set; }
    }
}