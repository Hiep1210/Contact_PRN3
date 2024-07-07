using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class Chatroom
    {
        public Chatroom()
        {
            Messages = new HashSet<Message>();
        }

        public int ChatId { get; set; }
        public int? User1 { get; set; }
        public int? User2 { get; set; }
        public string? Name { get; set; }

        public virtual User? User1Navigation { get; set; }
        public virtual User? User2Navigation { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
