using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trello.Core.Models;
using Trello.Infrastructure.DataContext;

namespace Trello.Infrastructure
{
    public static class ConfigureService
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration)
        {

            services.AddAuthentication(IdentityConstants.ApplicationScheme)
            .AddIdentityCookies();
            //services.AddAuthorizationBuilder();

            services.AddIdentityCore<User>()
                    .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }
    }
}
