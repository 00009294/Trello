namespace Trello.Core.Models
{
    public class Card : BaseEntity
    {
        public string Body { get; set; } = String.Empty;
        public Column? Column { get; set; }
        public int ColumnId { get; set; }

    }
}
