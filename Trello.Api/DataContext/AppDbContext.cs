using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Trello.Core.Models;

namespace Trello.Infrastructure.DataContext
{
    public class AppDbContext : IdentityDbContext<User>
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base (options) { }
            

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            
            builder.Entity<User>()
                .Ignore(u => u.AccessFailedCount)
                .Ignore(u => u.LockoutEnabled)
                .Ignore(u => u.LockoutEnd)
                .Ignore(u => u.TwoFactorEnabled)
                .Ignore(u => u.PhoneNumber);
            builder.Entity<User>().ToTable("Users");
            
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }

        public virtual DbSet<Board> Boards => Set<Board>();
        public virtual DbSet<Card> Cards => Set<Card>();
        public virtual DbSet<Column> Columns => Set<Column>();

        
    }

}
