using System;
using System.Collections.Generic;

namespace FinalPRN3.Models
{
    public partial class Image
    {
        public Image()
        {
            Contactdetails = new HashSet<Contactdetail>();
            Profiles = new HashSet<Profile>();
        }

        public int Id { get; set; }
        public string Url { get; set; } = null!;

        public virtual ICollection<Contactdetail> Contactdetails { get; set; }
        public virtual ICollection<Profile> Profiles { get; set; }
    }
}
