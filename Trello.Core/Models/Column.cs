using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trello.Core.Models
{
    public class Column : BaseEntity
    {
        public Board? Board { get; set; }
        public int BoardId { get; set; }
    }
}
