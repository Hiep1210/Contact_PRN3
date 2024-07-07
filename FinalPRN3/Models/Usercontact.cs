using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class Usercontact
    {
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public bool IsFavorite { get; set; } = false;
        public int GroupId { get; set; }
        public bool IsTrash { get; set; } = false;

        public virtual Contact Contact { get; set; } = null!;
        public virtual Contactgroup Group { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
