using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TabletopRpg.Framework.Authentication;
using TabletopRpg.Framework.DependencyInjection;

namespace TabletopRpg.Framework
{
    public static class MvcExtensions
    {
        public static void AddTabletopRpgFramework(this IServiceCollection services, Configuration configuration)
        {
            services.AddTabletopRpgAuthentication(configuration.JwtSecret);
            services.AddTabletopRpgDependencyInjection();
        }

        public static void UseTabletopRpgFramework(this IApplicationBuilder app)
        {
        }
    }
}