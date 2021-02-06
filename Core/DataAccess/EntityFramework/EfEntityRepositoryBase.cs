using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.DataAccess.EntityFramework
{
    public class EfEntityRepositoryBase <TEntity,TContext> : IEntityRepository<TEntity> // entity tipi ve Context tipi ile veriye ulasabiliriz
        where TEntity : class, IEntity, new()
        where TContext : DbContext, new ()
    {
        public void Add(TEntity entity)
        {
            //disposable pattern implemenatation of c#
            using (TContext context = new TContext())
            {
                var addedEntity = context.Entry(entity);
                addedEntity.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var deletedEntity = context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
        public TEntity Get(Expression<Func<TEntity, bool>> filter)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().SingleOrDefault(filter);
            }
        }
        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {

            // Filtre verebilsin filte null ise bir ilsem degilse diger islem calisiir
            //burasi bizim icin sql kodu olan select * products yapiyor
            using (TContext context = new TContext())
            {
                return filter == null
                        ? context.Set<TEntity>().ToList()
                       : context.Set<TEntity>().Where(filter).ToList();
            }
        }
        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var UpdatedEntity = context.Entry(entity);
                UpdatedEntity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

    }
}
