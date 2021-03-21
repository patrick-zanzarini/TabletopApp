using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TabletopRpg.Framework;
using TabletopRpg.Infra;

namespace TabletopRpgApp
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

            services.AddTabletopRpgFramework(new Configuration
            {
                JwtSecret = jwtKey
            });

            services.AddTabletopRpgInfra(connection);
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TabletopRpgDbContext context)
        {
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });

            app.UseTabletopRpgFramework();
            app.UseTabletopRpgInfra(context);
        }
    }
}