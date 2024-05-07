namespace Trello.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string Title { get; set; } = String.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; }
    }
}
