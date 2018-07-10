using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Proposals;

namespace SafeWeb.PurchaseApprover.Infrastructure.Repositories
{
    public class SupplierRepository : AbstractRepository<Supplier, int>, ISupplierRepository
    {
        public SupplierRepository(PurchaseApproverDbContext dbContext) : base(dbContext)
        {
        }
    }
}
