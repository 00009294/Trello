using Microsoft.AspNetCore.Identity;

namespace Trello.Core.Models
{
    public class User : IdentityUser
    {
        public string Name { get; set; } = string.Empty;
        public List<Board> Boards { get; set; }
    }
}
