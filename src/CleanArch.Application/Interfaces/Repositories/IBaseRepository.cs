using CleanArch.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces.Repositories
{
    public interface IBaseRepository<T> where T:BaseEntity
    {
        T Get(int id);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        List<T> GetAll(Expression<Func<T, bool>> filter = null);
    }
}
