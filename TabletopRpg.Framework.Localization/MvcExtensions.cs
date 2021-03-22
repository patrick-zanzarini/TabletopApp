using System.Globalization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.DependencyInjection;

namespace TabletopRpg.Framework.Localization
{
    public static class MvcExtensions
    {
        public static void AddTabletopRpgLocalization(this IServiceCollection services, string resourcesPath)
        {
            services.AddLocalization(opts =>  opts.ResourcesPath = resourcesPath);
        }
        
        public static void UseTabletopRpgLocalization(this IApplicationBuilder app, CultureInfo[] supported, RequestCulture @default)
        {
            app.UseRequestLocalization(new RequestLocalizationOptions()
            {
                DefaultRequestCulture = @default,
                SupportedCultures = supported,
                SupportedUICultures = supported
            });
        }
    }
}