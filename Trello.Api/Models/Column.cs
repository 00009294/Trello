namespace Trello.Core.Models
{
    public class Column : BaseEntity
    {
        public Board? Board { get; set; }
        public int BoardId { get; set; }
    }
}
