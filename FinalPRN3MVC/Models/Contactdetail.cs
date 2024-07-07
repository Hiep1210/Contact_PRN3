using System;
using System.Collections.Generic;

namespace FinalPRN3MVC.Models
{
    public partial class Contactdetail
    {
        public int ContactId { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? Image { get; set; }

        public virtual Contact Contact { get; set; } = null!;
        public virtual Image? ImageNavigation { get; set; }
    }
}
