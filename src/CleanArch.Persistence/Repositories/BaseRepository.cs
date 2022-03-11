using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Domain;
using CleanArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Repositories
{
    public class BaseRepository<T>:IBaseRepository<T> where T: BaseEntity
    {
        private readonly CleanArchContext context;
        private readonly IUnitOfWork UoW;
        public BaseRepository(CleanArchContext context, IUnitOfWork uoW)
        {
            this.context = context;
            UoW = uoW;
        }
        public DbSet<T> Table { get => context.Set<T>(); }

        public async Task<T> AddAsync(T model)
        {
            await Table.AddAsync(model);
            await UoW.SaveAsync();
            return model;
        }
        public async Task<List<T>> GetAsync()
        {
            return await Table.ToListAsync();
        }
        public async Task<T> GetByIdAsync(Guid id)
        {
            return await Table.FindAsync(id);
        }
        public async Task<List<T>> GetWhereAsync(Expression<Func<T, bool>> expression)
        {
            return await Table.Where(expression).ToListAsync();
        }

        public async Task<T> RemoveAsync(Guid Id)
        {
            var model = Table.Where(pre => pre.Id == Id).FirstOrDefault();
            Table.Remove(model);
            await UoW.SaveAsync();
            return model;
        }
    }
}
