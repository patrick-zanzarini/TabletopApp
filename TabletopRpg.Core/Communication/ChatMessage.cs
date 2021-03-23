using System;
using TabletopRpg.Core.Domain;

namespace TabletopRpg.Core.Communication
{
    public class ChatMessage : Entity
    {
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public string DisplayName { get; set; }

        public ChatRoom ChatRoom { get; set; }
        public User User { get; set; }
    }
}