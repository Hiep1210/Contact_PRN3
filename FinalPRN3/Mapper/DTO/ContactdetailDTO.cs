namespace FinalPRN3.Mapper.DTO
{
    public class ContactdetailDTO
    {
        public int ContactId { get; set; }
        public string Phone { get; set; } = null!;
        public string? Email { get; set; }
        public string? Address { get; set; }
        public int? Image { get; set; }
    }
}
