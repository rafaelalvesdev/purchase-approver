using Microsoft.EntityFrameworkCore;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Model.Administration;

namespace SafeWeb.PurchaseApprover.Infrastructure.Repositories
{
    public class UserProfileRepository : AbstractRepository<UserProfile, int>, IUserProfileRepository
    {
        public UserProfileRepository(PurchaseApproverDbContext dbContext) : base(dbContext)
        {
        }
    }
}
