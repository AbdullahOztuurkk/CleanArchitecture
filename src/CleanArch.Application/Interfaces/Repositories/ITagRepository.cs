using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces.Repositories
{
    public interface ITagRepository:IGenericRepository<Tag>
    {
        Task<List<Tag>> GetAllByDescription(string description);
    }
}
