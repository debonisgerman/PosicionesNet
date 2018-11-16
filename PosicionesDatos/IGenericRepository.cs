using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;
using System.Data.Entity.Infrastructure;

namespace PosicionesDatos
{
    public interface IGenericRepository<TEntity>
    where TEntity : class
    {
        IQueryable<TEntity> AsQueryable();

        IEnumerable<TEntity> AsEnumerable();

        DbQuery<TEntity> AsNoTracking();

        long Max(Func<TEntity, long> predicate);

        IQueryable<TEntity> WhereAsNoTracking(Expression<Func<TEntity, bool>> predicate, bool preloadData = true);

        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool preloadData = true);

        TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, bool preloadData = true);

        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate, bool preloadData = true);

        TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool preloadData = true);

        void Add(TEntity entity);

        void Delete(TEntity entity);

        void Attach(TEntity entity);

        void Dispose(bool disposing);

        void Dispose();
    }
}
