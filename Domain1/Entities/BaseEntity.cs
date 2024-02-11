namespace Domain.Entities
{
    public class BaseEntity
    {
        public DateTime CreatedAt { get; set; } = System.DateTime.Now;
        public string CreatedBy { get; set; } = "Admin";
        public DateTime? ModifiedAt { get; set; }
        public string? ModifiedBy { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
