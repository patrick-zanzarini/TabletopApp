using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TabletopRpg.DataAccess;
using TabletopRpg.DataAccess.Contexts;
using TabletopRpg.Framework;

namespace TabletopRpg.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var jwtKey = Encoding.ASCII.GetBytes(Configuration["Jwt:Secret"]);
            var connection = Configuration["SqlServer:ConnectionString"];

            services.AddCors();
            services.AddControllers();
            services.AddTabletopRpgFramework(new ServiceConfiguration
            {
                JwtSecret = jwtKey
            });
            services.AddTabletopRpgDataAccess(connection);

            services.AddLocalization(opts => opts.ResourcesPath = "Resources");
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TabletopRpgDbContext context)
        {
            app.UseStaticFiles();
            
            var supportedCultures = new CultureInfo[]
            {
                new("en-us"),
                new("pt-br")
            };
            app.UseTabletopRpgFramework(new ApplicationConfiguration()
                {DefaultCulture = new RequestCulture(supportedCultures[0]), SupportedCulture = supportedCultures});

            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseTabletopRpgDataAccess(context);

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}