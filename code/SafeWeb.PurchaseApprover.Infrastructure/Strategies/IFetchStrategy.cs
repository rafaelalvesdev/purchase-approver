using System.Linq;

namespace SafeWeb.PurchaseApprover.Infrastructure.Strategies
{
    public interface IFetchStrategy<TEntity>
    {
        IQueryable<TEntity> Configure(IQueryable<TEntity> queryable);
    }
}
