using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using UnicornCore.Interfaces.Services;
using UnicornCore.Models.DBContext;
using UnicornCore.Models.Infrastructure;
using UnicornCore.Models.Interfaces;
using UnicornCore.Services;

namespace UnicornCore
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true);

            if (env.IsEnvironment("Development"))
            {
                // This will push telemetry data through Application Insights pipeline faster, allowing you to view results immediately.
                builder.AddApplicationInsightsSettings(developerMode: true);
            }

            builder.AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var connection = @"Server=(localdb)\mssqllocaldb;Database=UnicornCore.Instance;Trusted_Connection=True;";
            services.AddDbContext<UnicornDBContext>(options => options.UseSqlServer(connection));

            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddMvc();

            services.AddTransient(typeof(IDBContext<>), typeof(InMemoryContext<>));
            services.AddTransient(typeof(IDBContext<>), typeof(EntityContext<>));
            services.AddTransient<IPersonService, PersonService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseApplicationInsightsRequestTelemetry();

            app.UseApplicationInsightsExceptionTelemetry();

            app.UseMvc();
        }
    }
}