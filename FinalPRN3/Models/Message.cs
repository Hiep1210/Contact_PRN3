using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class Message
    {
        public int Id { get; set; }
        public string Mess { get; set; } = null!;
        public DateTime? Senddate { get; set; }
        public int RoomId { get; set; }
        public int UserId { get; set; }

        public virtual Chatroom Room { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
