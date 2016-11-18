using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace AccountManager.DAL.EntityFramework
{
    abstract class EFRepository<TEntity, TDbContext> : IRepository<TEntity>
        where TEntity : class
        where TDbContext : DbContext
    {

        protected readonly TDbContext iDbContext;

        public EFRepository(TDbContext pContext)
        {
            if (pContext == null)
            {
                throw new ArgumentNullException(nameof(pContext));
            }

            this.iDbContext = pContext;
        }

        public void Add(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Add(pEntity);
        }

        public TEntity Get(int pId)
        {
            return this.iDbContext.Set<TEntity>().Find(pId);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.iDbContext.Set<TEntity>().ToList();
        }

        public void Remove(TEntity pEntity)
        {
            if (pEntity == null)
            {
                throw new ArgumentNullException(nameof(pEntity));
            }

            this.iDbContext.Set<TEntity>().Remove(pEntity);
        }
    }
}
