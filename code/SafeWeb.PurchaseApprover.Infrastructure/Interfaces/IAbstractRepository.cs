using SafeWeb.PurchaseApprover.Infrastructure.Strategies;
using System.Collections.Generic;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Infrastructure.Interfaces
{
    public interface IAbstractRepository<TEntity, TKey>
    {
        TEntity Create(TEntity entity);
        void Create(IEnumerable<TEntity> entities);
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> Get();
        TEntity GetById(TKey id);
        IQueryable<TEntity> Get<TFetch>() where TFetch : IFetchStrategy<TEntity>;
        void Delete(TEntity entity);
        void DeleteLogically(TEntity entity);
        void Update(TEntity entity);
        void Update(IEnumerable<TEntity> entities);
        void Attach(params object[] entities);
    }
}
