using JSNLog;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Serialization;
using NLog.Extensions.Logging;
using NLog.Web;

namespace Vouchers
{
    public class Startup
    {
        private readonly IHostingEnvironment env;

        public Startup(IHostingEnvironment environment)
        {
            env = environment;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            //Config
            var cfgBuilder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json");
            var configuration = cfgBuilder.Build();
            services.Configure<VouchersConfig>(configuration);
            services.AddSingleton(typeof(IConfigurationRoot), configuration);
            var conStr = configuration["ConnectionStrings:SQLServerDBConnection"];

            //EF
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<VouchersDBContext>(options => options.UseSqlServer(conStr));
            services.AddScoped<IVouchersRepository, VouchersRepository>();

            //CORS
            var corsBuilder = new CorsPolicyBuilder();
            corsBuilder.AllowAnyHeader();
            corsBuilder.AllowAnyMethod();
            corsBuilder.AllowAnyOrigin();
            // For specific URL 
            // corsBuilder.WithOrigins("http://localhost:4200")
            corsBuilder.AllowCredentials();

            services.AddCors(options =>
            {
                options.AddPolicy("AllowAll",
                    builder => builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials());
            });

            //Serialization Options
            services.AddMvc().AddJsonOptions(ser =>
            {
                ser.SerializerSettings.ContractResolver =
                    new DefaultContractResolver();
            });
        }

        public void Configure(IApplicationBuilder app, ILoggerFactory loggerFactory)
        {
            //Logging
            loggerFactory.AddNLog();
            env.ConfigureNLog("nlog.config");

            var jsnlogConfiguration = new JsnlogConfiguration();
            app.UseJSNLog(new LoggingAdapter(loggerFactory), jsnlogConfiguration);

            if (env.IsDevelopment())
            {
                loggerFactory.AddConsole();
                loggerFactory.AddDebug();
                app.UseDeveloperExceptionPage();
                app.UseStatusCodePages();
            }

            //Startup File
            var options = new DefaultFilesOptions();
            options.DefaultFileNames.Clear();
            options.DefaultFileNames.Add("crud.html");
            app.UseDefaultFiles(options);

            if (env.IsDevelopment())
                app.UseStaticFiles(new StaticFileOptions
                {
                    OnPrepareResponse = context =>
                    {
                        context.Context.Response.Headers["Cache-Control"] = "no-cache, no-store";
                        context.Context.Response.Headers["Pragma"] = "no-cache";
                        context.Context.Response.Headers["Expires"] = "-1";
                    }
                });
            else
                app.UseStaticFiles();

            //Cors
            app.UseCors("AllowAll");

            app.UseMvcWithDefaultRoute();
        }
    }
}