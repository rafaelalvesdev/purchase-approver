using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Proposals;

namespace SafeWeb.PurchaseApprover.Infrastructure.Repositories
{
    public class CategoryRepository : AbstractRepository<Category, int>, ICategoryRepository
    {
        public CategoryRepository(PurchaseApproverDbContext dbContext) : base(dbContext)
        {
        }
    }
}
