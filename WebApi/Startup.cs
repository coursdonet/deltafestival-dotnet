using AutoMapper;
using Database;
using DeltaFestival.IRepository;
using DeltaFestival.Repository;
using DeltaFestivalAPI.Helpers;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using System.IO;
using System.Text;
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
            services.AddCors()

            //#region DI
            //    // Add useful interface for accessing the ActionContext outside a controller.
            //    .AddSingleton<IActionContextAccessor, ActionContextAccessor>()
            //    // Add useful interface for accessing the HttpContext outside a controller.
            //    .AddSingleton<IHttpContextAccessor, HttpContextAccessor>()
            //    // Add useful interface for accessing the IUrlHelper outside a controller.
            //    .AddScoped<IUrlHelper>(x => x
            //        .GetRequiredService<IUrlHelperFactory>()
            //        .GetUrlHelper(x.GetRequiredService<IActionContextAccessor>().ActionContext))
            //#endregion

                    .AddMvcCore(options =>
                {
                    options.Filters.Add(new CacheControlFilter());  // Add "Cache-Control" header. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#cache-control
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

            services.AddDbContext<EfContext>(options => options.UseSqlServer(
                Configuration.GetConnectionString("FestivalDb")
                , x => x.MigrationsAssembly("Database")));

            //AutoMapper
            services.AddAutoMapper();   // Check out Configuration/AutoMapperProfiles/DefaultProfile to do actual configuration. See: https://github.com/drwatson1/AspNet-Core-REST-Service/wiki#automapper


            // Register the Swagger generator, defining 1 or more Swagger documents



            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "Delta Festival Swagger", Version = "v1" });
            });



            services.Add(new ServiceDescriptor(typeof(IMoodRepository), typeof(MoodRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IPublicationRepository), typeof(PublicationRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IRoleRepository), typeof(RoleRepository), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IUserRepository), typeof(UserRepository), ServiceLifetime.Transient));
            //services.Add(new ServiceDescriptor(typeof()))

            // configure strongly typed settings objects
            var appSettingsSection = Configuration.GetSection("AppSettings");
            services.Configure<AppSettings>(appSettingsSection);

            // configure jwt authentication
            var appSettings = appSettingsSection.Get<AppSettings>();
            var key = Encoding.ASCII.GetBytes("TESTTOKEN");
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
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

            app.UseAuthentication();

            app.UseCors(x => x
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());


            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("./v1/swagger.json", "Api v1");
            });

            //app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
