namespace FinalPRN3.Mapper.DTO
{
    public class UsercontactDTO
    {
        public int UserId { get; set; }
        public int ContactId { get; set; }
        public bool IsFavorite { get; set; } = false;
        public int GroupId { get; set; } = 0;
        public bool IsTrash { get; set; } = false;
    }
}
