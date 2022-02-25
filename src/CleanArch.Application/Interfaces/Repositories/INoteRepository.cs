using CleanArch.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces.Repositories
{
    public interface INoteRepository:IGenericRepository<Note>
    {
        Task<List<Note>> GetAllByContent(string content);
        Task<List<Note>> GetAllByTag(string name);
    }
}
