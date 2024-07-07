using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class Contactgroup
    {
        public Contactgroup()
        {
            Usercontacts = new HashSet<Usercontact>();
        }

        public int Groupid { get; set; }
        public int Ownerid { get; set; }
        public string? Groupname { get; set; }

        public virtual User Owner { get; set; } = null!;
        public virtual ICollection<Usercontact> Usercontacts { get; set; }
    }
}
