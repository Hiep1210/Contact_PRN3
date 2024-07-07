using System;
using System.Collections.Generic;

namespace FinalPRN3MVC.Models
{
    public partial class Profile
    {
        public int ProfileId { get; set; }
        public int? UserId { get; set; }
        public string? Realname { get; set; }
        public DateOnly? Dob { get; set; }
        public int? Image { get; set; }

        public virtual Image? ImageNavigation { get; set; }
        public virtual User? User { get; set; }
    }
}
