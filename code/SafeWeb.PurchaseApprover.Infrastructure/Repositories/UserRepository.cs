using Microsoft.EntityFrameworkCore;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Administration;

namespace SafeWeb.PurchaseApprover.Infrastructure.Repositories
{
    public class UserRepository : AbstractRepository<User, int>, IUserRepository
    {
        public UserRepository(PurchaseApproverDbContext dbContext) : base(dbContext)
        {
        }
    }
}
