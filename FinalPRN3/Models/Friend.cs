using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class Friend
    {
        public int UserId { get; set; }
        public int FriendId { get; set; }
        public string Status { get; set; } = null!;
        public DateTime? RequestDate { get; set; }

        public virtual User FriendNavigation { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
