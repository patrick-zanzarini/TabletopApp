using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using TabletopRpg.Framework.Authentication;
using TabletopRpg.Framework.DependencyInjection;
using TabletopRpg.Framework.Localization;

namespace TabletopRpg.Framework
{
    public static class MvcExtensions
    {
        public static void AddTabletopRpgFramework(this IServiceCollection services, ServiceConfiguration config)
        {
            services.AddTabletopRpgLocalization(config.ResourcePath);
            services.AddTabletopRpgAuthentication(config.JwtSecret);
            services.AddTabletopRpgDependencyInjection();
        }

        public static void UseTabletopRpgFramework(this IApplicationBuilder app, ApplicationConfiguration config)
        {
            app.UseTabletopRpgLocalization(config.SupportedCulture, config.DefaultCulture);
        }
    }
}