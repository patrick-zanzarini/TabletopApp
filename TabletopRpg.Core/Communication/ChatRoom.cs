using TabletopRpg.Core.Domain;
using TabletopRpg.Core.Rooms;

namespace TabletopRpg.Core.Communication
{
    public class ChatRoom: Entity
    {
        public Room Room { get; set; }
    }
}