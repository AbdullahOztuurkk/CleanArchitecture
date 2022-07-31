using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace CleanArch.Persistence.Repositories
{
    public class BaseRepository<TContext,TEntity>:IBaseRepository<TEntity> 
        where TEntity: BaseEntity
        where TContext: DbContext,new()
    {
        public void Add(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                var currentUser = context.Entry<TEntity>(entity);
                currentUser.State = EntityState.Added;
                context.SaveChanges();
            }
        }

        public void Delete(int Id)
        {
            using (TContext context = new TContext())
            {
                var entity = context.Set<TEntity>().FirstOrDefault(p => p.Id == Id);
                context.Remove(entity);
                context.SaveChanges();
            }
        }

        public TEntity Get(int id)
        {
            using (TContext context = new TContext())
            {
                return context.Set<TEntity>().Where(entity => entity.Id == id).FirstOrDefault();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }

        public void Update(TEntity entity)
        {
            using (TContext context = new TContext())
            {
                context.Entry<TEntity>(entity).State = EntityState.Modified;
                context.SaveChanges();
            }
        }
    }
}
