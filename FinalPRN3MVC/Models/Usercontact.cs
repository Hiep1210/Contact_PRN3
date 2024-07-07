using System;
using System.Collections.Generic;

namespace FinalPRN3MVC.Models
{
    public partial class Usercontact
    {
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public sbyte? IsFavorite { get; set; }
        public int GroupId { get; set; }

        public virtual Contact Contact { get; set; } = null!;
        public virtual Contactgroup Group { get; set; } = null!;
        public virtual User User { get; set; } = null!;
    }
}
