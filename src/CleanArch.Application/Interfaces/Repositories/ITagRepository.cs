using CleanArch.Domain.Entities;
using System.Collections.Generic;

namespace CleanArch.Application.Interfaces.Repositories
{
    public interface ITagRepository:IBaseRepository<Tag>
    {
        List<Tag> GetAllByDescription(string description);
    }
}
