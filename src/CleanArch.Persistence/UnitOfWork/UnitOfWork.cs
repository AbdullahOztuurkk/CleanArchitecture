using CleanArch.Application.Interfaces.Repositories;
using CleanArch.Application.Interfaces.UnitOfWork;
using CleanArch.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        public UnitOfWork(
            CleanArchContext context,
            INoteRepository NoteRepository,
            ITagRepository TagRepository)
        {
            Context = context;
            this.NoteRepository = NoteRepository;
            this.TagRepository = TagRepository;
        }
        public INoteRepository NoteRepository { get; }
        public ITagRepository TagRepository { get; }
        public CleanArchContext Context { get; }

        public async Task<int> SaveAsync()
        {
            return await Context.SaveChangesAsync();
        }
    }
}
