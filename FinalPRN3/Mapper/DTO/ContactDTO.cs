using FinalPRN3.Models;

namespace FinalPRN3.Mapper.DTO
{
    public class ContactDTO
    {
        public int Id { get; set; }
        public string? ContactName { get; set; }

        public Contactdetail? Contactdetail { get; set; }
    }
}
