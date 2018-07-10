using Microsoft.EntityFrameworkCore;
using SafeWeb.PurchaseApprover.Infrastructure.Extensions;
using SafeWeb.PurchaseApprover.Infrastructure.Interfaces;
using SafeWeb.PurchaseApprover.Infrastructure.Strategies;
using SafeWeb.PurchaseApprover.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SafeWeb.PurchaseApprover.Infrastructure.Repositories
{
    public abstract class AbstractRepository<TEntity, TKey> : IAbstractRepository<TEntity, TKey>
            where TEntity : BaseEntity<TKey>
    {
        public DbContext DbContext;

        #region .ctor
        public AbstractRepository(DbContext dbContext)
        {
            DbContext = dbContext;
        }
        #endregion

        #region [ CRUD ]

        public TEntity Create(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Add(entity);
            DbContext.SaveChanges();
            return entity;
        }

        public void Create(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");
            DbContext.Set<TEntity>().AddRange(entities);
            DbContext.SaveChanges();
        }

        public IQueryable<TEntity> GetAll()
        {
            return DbContext.Set<TEntity>().AsQueryable();
        }

        public IQueryable<TEntity> Get()
        {
            return DbContext.Set<TEntity>().AsQueryable().Where(x => !x.IsDeleted);
        }

        public IQueryable<TEntity> Get<TFetch>()
            where TFetch : IFetchStrategy<TEntity>
        {
            return Get().Configure<TEntity, TFetch>();
        }

        public TEntity GetById(TKey id)
        {
            return Get().FirstOrDefault(e => e.ID.Equals(id));
        }

        public void Delete(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Remove(entity);
            DbContext.SaveChanges();
        }

        public void DeleteLogically(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            entity.IsDeleted = true;
            DbContext.Set<TEntity>().Update(entity);
            DbContext.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            DbContext.Set<TEntity>().Update(entity);
            DbContext.SaveChanges();
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            if (entities == null) throw new ArgumentNullException("entities");

            DbContext.Set<TEntity>().UpdateRange(entities);

            DbContext.SaveChanges();
        }
        
        public void Attach(params object[] entities)
        {
            for (var i = 0; i < entities.Length; i++)
                DbContext.Attach(entities[i]);
        }
        #endregion
    }
}

