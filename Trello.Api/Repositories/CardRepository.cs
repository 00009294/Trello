using Trello.Api.Repositories.Persistence;
using Trello.Core.Models;
using Trello.Infrastructure.DataContext;

namespace Trello.Api.Repositories
{
    public class CardRepository
        : EfBaseRepository<Card, AppDbContext>
    {
        public CardRepository(AppDbContext context)
            : base(context)
        {
        }
    }
}
