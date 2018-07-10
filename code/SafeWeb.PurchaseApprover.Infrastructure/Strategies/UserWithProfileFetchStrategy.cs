using Microsoft.EntityFrameworkCore;
using SafeWeb.PurchaseApprover.Model.Administration;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Infrastructure.Strategies
{
    public class UserWithProfileFetchStrategy : IFetchStrategy<User>
    {
        public IQueryable<User> Configure(IQueryable<User> queryable)
        {
            return queryable.Include(x => x.UserProfile).ThenInclude(x => x.ProfileRoles);
        }
   }
}