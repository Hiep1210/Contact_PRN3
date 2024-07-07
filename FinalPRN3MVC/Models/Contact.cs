using System;
using System.Collections.Generic;

namespace FinalPRN3MVC.Models
{
    public partial class Contact
    {
        public Contact()
        {
            Usercontacts = new HashSet<Usercontact>();
        }

        public int Id { get; set; }
        public string? ContactName { get; set; }

        public virtual Contactdetail? Contactdetail { get; set; }
        public virtual ICollection<Usercontact> Usercontacts { get; set; }
    }
}
