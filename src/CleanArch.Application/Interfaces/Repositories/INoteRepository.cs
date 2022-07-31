using CleanArch.Domain.Entities;
using System.Collections.Generic;

namespace CleanArch.Application.Interfaces.Repositories
{
    public interface INoteRepository:IBaseRepository<Note>
    {
        List<Note> GetAllByContent(string content);
        List<Note> GetAllByTag(string name);
    }
}
