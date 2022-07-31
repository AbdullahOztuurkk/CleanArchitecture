using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Context;
using System.Collections.Generic;

namespace CleanArch.Persistence.Repositories
{
    public class TagRepository : BaseRepository<CleanArchContext,Tag>, ITagRepository
    {
        public List<Tag> GetAllByDescription(string description)
        {
            return base.GetAll(predicate => predicate.Description.Contains(description));
        }
    }
}
