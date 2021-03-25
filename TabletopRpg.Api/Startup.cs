using System;
using System.Globalization;
using System.Text;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Localization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TabletopRpg.Api.Hubs;
using TabletopRpg.DataAccess;
using TabletopRpg.DataAccess.Contexts;
using TabletopRpg.Framework;

namespace TabletopRpg.Api
{
    public class Startup
    {
        const string CORS_POLICY = "CorsPolicy";

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

            services.AddSignalR();

            services.AddCors(options =>
            {
                options.AddPolicy(CORS_POLICY, x => x
                    .WithOrigins("http://localhost:4200")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
                );
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, TabletopRpgDbContext context)
        {
            app.UseCors(CORS_POLICY);

            app.UseStaticFiles();

            app.UseTabletopRpgFramework();
            app.UseTabletopRpgDataAccess(context);

            app.UseRouting();

            UseAndConfigWebsocket(app);

            app.UseAuthentication();
            // app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<RoomChatHub>("/room-chat");
            });
        }

        private static void UseAndConfigWebsocket(IApplicationBuilder app)
        {
            var webSocketOptions = new WebSocketOptions()
            {
                KeepAliveInterval = TimeSpan.FromSeconds(120),
            };

            webSocketOptions.AllowedOrigins.Add("http://localhost:4200");
            ;
            webSocketOptions.AllowedOrigins.Add("https://localhost:4200");
            ;

            app.UseWebSockets(webSocketOptions);
        }
    }
}