using System;
using System.IO;
using System.Reflection;
using AutoMapper;
using Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Filters;

namespace WebApi
{
    public class Startup
    {
        ILogger<Startup> Logger { get; }
        public static IConfiguration Configuration { get; private set; }

        public Startup(IConfiguration configuration, IHostingEnvironment env, ILogger<Startup> logger)
        {
            Logger = logger;
            Startup.Configuration = configuration;

            // https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#using-environment-variables-in-configuration-options
            var envPath = Path.Combine(env.ContentRootPath, ".env");
            if (File.Exists(envPath))
            {
                DotNetEnv.Env.Load();
            }

            // See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#content-formatting
            JsonConvert.DefaultSettings = () =>
                new JsonSerializerSettings()
                {
                    ContractResolver = new CamelCasePropertyNamesContractResolver(),
                    NullValueHandling = NullValueHandling.Ignore,
                    DefaultValueHandling = DefaultValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
#if DEBUG
                    Formatting = Formatting.Indented
#else
                    Formatting = Formatting.None
#endif
                };

        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            //cors
            services.AddCors();
           
            services.AddMvcCore(options =>
                {
                    options.Filters.Add(new CacheControlFilter());  // Add "Cache-Control" header. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#cache-control
                    options.Filters.Add(new ApiExceptionFilterAttribute());
                })
               .AddApiExplorer()
                .AddJsonFormatters()    // See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#content-formatting
                .AddJsonOptions(options =>
                {
                    options.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                    options.SerializerSettings.DefaultValueHandling = DefaultValueHandling.Include;
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
#if DEBUG
                    options.SerializerSettings.Formatting = Formatting.Indented;
#else
                    options.SerializerSettings.Formatting = Formatting.None;
#endif
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region DB & context 
            services.AddDbContext<EfContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("FestivalDb")
                , x => x.MigrationsAssembly("Database")));

            services.AddDbContext<CpContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("CheckpointDb")
                , x => x.MigrationsAssembly("Database")));

            services.AddDbContext<BrownContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("BrownDb")
                , x => x.MigrationsAssembly("Database")));
            #endregion

            //AutoMapper
            services.AddAutoMapper();   // Check out Configuration/AutoMapperProfiles/DefaultProfile to do actual configuration. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#automapper


            // Register the Swagger generator, defining 1 or more Swagger documents      
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
            });


        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
               app.UseDeveloperExceptionPage();


            }
            else
            {
                app.UseHsts();
            }
            
           
            // app.UseStatusCodePagesWithReExecute("Error/{0}");
            // app.UseExceptionHandler("/Error/500");
            app.UseStaticFiles();

            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), 
            // specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("../swagger/v1/swagger.json", "API V1");
            });

            app.UseHttpsRedirection();
            app.UseMvc();

            //custom routes if need
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=test}/{action=get}/{id?}");
            });
            //Conventional routing
            app.UseMvcWithDefaultRoute();

            //Catch-all route
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "catch-all",
                    template: "{*url}",
                    defaults: new { controller = "Error", action = "Message" });
                ;
            });

        }
    }
}
