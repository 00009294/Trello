using Trello.Api.Repositories.Persistence;
using Trello.Core.Models;
using Trello.Infrastructure.DataContext;

namespace Trello.Api.Repositories
{
    public class BoardRepository
        : EfBaseRepository<Board, AppDbContext>
    {
        public BoardRepository(AppDbContext appDbContext)
            : base(appDbContext)
        {

        }
    }
}
