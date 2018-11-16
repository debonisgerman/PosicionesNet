using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity.Infrastructure;
using System.Linq.Expressions;

namespace PosicionesDatos
{
    public class GenericRepository<TContext, TEntity> : IGenericRepository<TEntity>
        where TContext : IUnitOfWork
        where TEntity : class
    {
        protected TContext _context;

        protected GenericRepository() { }

        /// <summary>
        /// Constructor that takes a context
        /// </summary>
        /// <param name="context">An established data context</param>
        public GenericRepository(TContext context)
        {
            _context = context;
        }

        public IQueryable<TEntity> AsQueryable()
        {
            return _context.Set<TEntity>().AsQueryable();
        }

        public IEnumerable<TEntity> AsEnumerable()
        {
            return _context.Set<TEntity>().AsEnumerable();
        }

        public DbQuery<TEntity> AsNoTracking()
        {
            return _context.Set<TEntity>().AsNoTracking();
        }

        public long Max(Func<TEntity, long> predicate)
        {
            return _context.Set<TEntity>().Max(predicate);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public IQueryable<TEntity> WhereAsNoTracking(Expression<Func<TEntity, bool>> predicate, bool preloadData = true)
        {
            if (preloadData)
            {
                //Preload the entire table into the context
                Func<TEntity, bool> func = predicate.Compile();
                return _context.Set<TEntity>().AsNoTracking().Where(func).AsQueryable<TEntity>();
            }
            else
            {
                //Don´t preload the entire table into the context, just get the selected rows
                return _context.Set<TEntity>().AsNoTracking().Where(predicate);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="preloadData">preloadData = true => Preload the entire table into the context</param>
        /// <returns></returns>
        public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate, bool preloadData = true)
        {
            if (preloadData)
            {
                //Preload the entire table into the context
                Func<TEntity, bool> func = predicate.Compile();
                return _context.Set<TEntity>().Where(func).AsQueryable<TEntity>();
            }
            else
            {
                //Don´t preload the entire table into the context, just get the selected rows
                return _context.Set<TEntity>().Where(predicate);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="preloadData">preloadData = true => Preload the entire table into the context</param>
        /// <returns></returns>
        public TEntity GetSingle(Expression<Func<TEntity, bool>> predicate, bool preloadData = true)
        {
            if (preloadData)
            {
                //Preload the entire table into the context
                Func<TEntity, bool> func = predicate.Compile();
                return _context.Set<TEntity>().Single(func);
            }
            else
            {
                //Don´t preload the entire table into the context, just get the selected row
                return _context.Set<TEntity>().Single(predicate);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="preloadData">preloadData = true => Preload the entire table into the context</param>
        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate, bool preloadData = true)
        {
            if (preloadData)
            {
                //Preload the entire table into the context
                Func<TEntity, bool> func = predicate.Compile();
                return _context.Set<TEntity>().First(func);
            }
            else
            {
                //Don´t preload the entire table into the context, just get the selected row
                return _context.Set<TEntity>().First(predicate);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="predicate"></param>
        /// <param name="preloadData">preloadData = true => Preload the entire table into the context</param>
        public TEntity GetFirstOrDefault(Expression<Func<TEntity, bool>> predicate, bool preloadData = true)
        {
            if (preloadData)
            {
                //Preload the entire table into the context
                Func<TEntity, bool> func = predicate.Compile();
                return _context.Set<TEntity>().FirstOrDefault(func);
            }
            else
            {
                //Don´t preload the entire table into the context, just get the selected row
                return _context.Set<TEntity>().FirstOrDefault(predicate);
            }
        }

        public bool Any(Expression<Func<TEntity, bool>> predicate)
        {
            return _context.Set<TEntity>().Any(predicate);
        }

        public void Add(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Cannot add a null entity");

            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Cannot delete a null entity");

            _context.Set<TEntity>().Remove(entity);
        }

        public void Attach(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentException("Cannot attach a null entity");

            _context.Set<TEntity>().Attach(entity);
        }

        #region IDisposable implementation
        private bool disposedValue;

        public void Dispose(bool disposing)
        {
            if (!this.disposedValue)
            {
                if (disposing)
                {
                    // dispose managed state here if required
                }
                // dispose unmanaged objects and set large fields to null
            }
            this.disposedValue = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
