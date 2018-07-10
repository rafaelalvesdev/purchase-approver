using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Infrastructure.Repositories;

namespace SafeWeb.PurchaseApprover.Infrastructure
{
    public class Startup
    {
        public static void Configure(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserProfileRepository, UserProfileRepository>();

            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<IProposalRepository, ProposalRepository>();            


            var dbContext = services.BuildServiceProvider().GetRequiredService<PurchaseApproverDbContext>();
            dbContext.Database.Migrate();
            DbDataSeeder.Seed(dbContext);
        }
    }
}
