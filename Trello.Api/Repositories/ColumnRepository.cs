using Trello.Api.Repositories.Persistence;
using Trello.Core.Models;
using Trello.Infrastructure.DataContext;

namespace Trello.Api.Repositories
{
    public class ColumnRepository 
        : EfBaseRepository<Column, AppDbContext>
    {
        public ColumnRepository(AppDbContext context) : base(context)
        {
        }
    }
}
