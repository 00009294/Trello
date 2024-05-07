using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Core.Models
{
    public class Card : BaseEntity
    {
        public string Body { get; set; } = String.Empty;
        public Column? Column { get; set; }
        public int ColumnId { get; set; }

    }
}
