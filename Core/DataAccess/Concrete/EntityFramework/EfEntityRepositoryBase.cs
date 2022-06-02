using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Core.Entities.Abstract;
using Microsoft.EntityFrameworkCore;

namespace Core.DataAccess.Concrete.EntityFramework
{
    public class EfEntityRepositoryBase<TEntity, TContext> : IEntityRepository<TEntity>
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new()
    {
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (var context = new TContext())
            {
                var record = context.Set<TEntity>().FirstOrDefault(filter);

                return record;
            }
        }

        public IList<TEntity> GetList(Expression<Func<TEntity, bool>>? filter)
        {
            using (var context = new TContext())
            {
                if (filter==null)
                {
                    var records = context.Set<TEntity>().ToList();
                    return records;
                }
                else
                {
                    var records = context.Set<TEntity>().Where(filter).ToList();
                    return records;
                }

            }
        }

        public TEntity Add(TEntity entity)
        {
            using (var context = new TContext())
            {
                var record = context.Set<TEntity>().Add(entity);
                context.SaveChanges();

                return entity;
            }
        }

        public void Update(TEntity entity)
        {
            using (var context = new TContext())
            {
                var record = context.Set<TEntity>().Update(entity);
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (var context = new TContext())
            {
                var record = context.Set<TEntity>().Remove(entity);
                context.SaveChanges();
            }
        }
    }
}
