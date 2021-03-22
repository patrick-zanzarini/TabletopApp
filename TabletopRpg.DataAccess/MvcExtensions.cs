using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace TabletopRpg.Infra
{
    public static class MvcExtensions
    {
        public static void AddTabletopRpgInfra(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TabletopRpgDbContext>(
                options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("TabletopRpg.DataAccess"))
            );
        }
        
        public static void UseTabletopRpgInfra(this IApplicationBuilder app, TabletopRpgDbContext context)
        {
            context.Database.Migrate();
        }
    }
}