using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace CleanArch.Persistence.Repositories
{
    public class NoteRepository:BaseRepository<CleanArchContext,Note>,INoteRepository
    {
        private readonly CleanArchContext context;
        public NoteRepository(CleanArchContext context)
        {
            this.context = context;
        }

        public List<Note> GetAllByContent(string content)
        {
            return base.GetAll(note => note.Content.Contains(content));
        }

        public List<Note> GetAllByTag(string name)
        {
            using (CleanArchContext context = new CleanArchContext())
            {
                return context.Notes.Include(p => p.Tag).Where(predicate => predicate.Tag.Name.Contains(name)).ToList();
            }   
        }
    }
}
