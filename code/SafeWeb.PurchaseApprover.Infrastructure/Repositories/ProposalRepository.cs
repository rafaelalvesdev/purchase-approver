using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Proposals;

namespace SafeWeb.PurchaseApprover.Infrastructure.Repositories
{
    public class ProposalRepository : AbstractRepository<Proposal, int>, IProposalRepository
    {
        public ProposalRepository(PurchaseApproverDbContext dbContext) : base(dbContext)
        {
        }
    }
}
