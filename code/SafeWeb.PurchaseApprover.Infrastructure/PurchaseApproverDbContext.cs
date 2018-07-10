using Microsoft.EntityFrameworkCore;
using SafeWeb.PurchaseApprover.Model.Administration;
using SafeWeb.PurchaseApprover.Model.Proposals;

namespace SafeWeb.PurchaseApprover.Infrastructure
{
    public class PurchaseApproverDbContext : DbContext
    {
        public PurchaseApproverDbContext(DbContextOptions<PurchaseApproverDbContext> options)
            : base(options) { }


        public DbSet<User> Users { get; set; }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<ProfileRole> ProfileRoles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Proposal> Proposals { get; set; }
        public DbSet<Configuration> Configurations { get; set; }



        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<ProfileRole>().HasKey(e => new { e.Role, e.UserProfileID });

            base.OnModelCreating(builder);
        }
    }
}
