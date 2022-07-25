using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Repositories
{
    public class NoteRepository:BaseRepository<Note>,INoteRepository
    {
        private readonly CleanArchContext context;
        public NoteRepository(CleanArchContext context):base(context)
        {
            this.context = context;
        }

        public Task<List<Note>> GetAllByContent(string content)
        {
            var result = Table.Where(predicate => predicate.Content.Contains(content)).ToList();
            return Task.FromResult(result);
        }

        public Task<List<Note>> GetAllByTag(string name)
        {
            var result = context.Notes.Include(p => p.Tag).Where(predicate => predicate.Tag.Name.Contains(name)).ToList();
            return Task.FromResult(result);
        }
    }
}
