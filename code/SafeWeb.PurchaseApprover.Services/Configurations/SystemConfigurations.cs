using SafeWeb.PurchaseApprover.Infrastructure;

namespace SafeWeb.PurchaseApprover.Services.Configurations
{
    public class SystemConfigurations : AbstractConfigurator
    {
        public SystemConfigurations(PurchaseApproverDbContext dbContext) : base(dbContext)
        {
        }

        public int PurchaseProposal_HoursToExpire { get; set; }
    }
}
