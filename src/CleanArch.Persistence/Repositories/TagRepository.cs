using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(CleanArchContext context) : base(context) { }

        public Task<List<Tag>> GetAllByDescription(string description)
        {
            var result = Table.Where(predicate => predicate.Description.Contains(description)).ToList();
            return Task.FromResult(result);
        }
    }
}
