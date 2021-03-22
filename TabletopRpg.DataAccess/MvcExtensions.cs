using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TabletopRpg.DataAccess.Contexts;

namespace TabletopRpg.DataAccess
{
    public static class MvcExtensions
    {
        public static void AddTabletopRpgDataAccess(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<TabletopRpgDbContext>(
                options => options.UseSqlServer(connectionString, x => x.MigrationsAssembly("TabletopRpg.DataAccess"))
            );
        }
        
        public static void UseTabletopRpgDataAccess(this IApplicationBuilder app, TabletopRpgDbContext context)
        {
            context.Database.Migrate();
        }
    }
}