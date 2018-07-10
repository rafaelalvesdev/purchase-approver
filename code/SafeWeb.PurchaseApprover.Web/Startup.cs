using AutoMapper;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeWeb.PurchaseApprover.Infrastructure;
using SafeWeb.PurchaseApprover.Web.Mappers;
using SafeWeb.PurchaseApprover.Web.Middlewares;
using Swashbuckle.AspNetCore.Swagger;

namespace SafeWeb.PurchaseApprover.Web
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                .AddSessionStateTempDataProvider();

            services.AddSession();

            // Mapper
            Mapper.Initialize(cfg =>
            {
                cfg.AddProfile<UserMappingProfile>();
                cfg.AddProfile<SupplierMappingProfile>();
                cfg.AddProfile<CategoryMappingProfile>();

                SafeWeb.PurchaseApprover.Services.Startup.ConfigureMappers(cfg);
            });

            // DB Connection
            services.AddDbContext<PurchaseApproverDbContext>(options =>
            {
                string assemblyName = typeof(Startup).Assembly.GetName().Name;
                var connectionString = Configuration.GetConnectionString("DefaultConnection");
                options.UseSqlServer(connectionString, b => b.MigrationsAssembly(assemblyName).UseRowNumberForPaging());
            });

            // Dependency Injection
            SafeWeb.PurchaseApprover.Infrastructure.Startup.Configure(services, Configuration);
            SafeWeb.PurchaseApprover.Services.Startup.Configure(services);


            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie();

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/dist";
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "SafeWeb.PurchaseApprover", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
            }

            app.UseSession();
            //app.UseMiddleware<AuthenticationMiddleware>();
            //app.UseMiddleware<ErrorHandlerMiddleware>();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });


            app.UseStaticFiles();
            app.UseSpaStaticFiles();            
            app.UseMvc();
            app.UseAuthentication();

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseAngularCliServer(npmScript: "start");
                }
            });
        }
    }
}
