using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using SafeWeb.PurchaseApprover.Services.Configurations;
using SafeWeb.PurchaseApprover.Services.Implementation;
using SafeWeb.PurchaseApprover.Services.Interfaces;
using SafeWeb.PurchaseApprover.Services.Mappers;

namespace SafeWeb.PurchaseApprover.Services
{
    public class Startup
    {
        public static void Configure(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<ISupplierService, SupplierService>();
            services.AddTransient<IProposalService, ProposalService>();

            services.AddScoped<SystemConfigurations>();
        }

        public static void ConfigureMappers(IMapperConfigurationExpression cfg)
        {
            cfg.AddProfile<GeneralMappingProfile>();
            cfg.AddProfile<UserServiceMappingProfile>();
            cfg.AddProfile<SupplierServiceMappingProfile>();
            cfg.AddProfile<CategoryServiceMappingProfile>();
        }
    }
}
