using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class Useractivity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime? Date { get; set; }
        public string Action { get; set; } = null!;

        public virtual User User { get; set; } = null!;
    }
}
