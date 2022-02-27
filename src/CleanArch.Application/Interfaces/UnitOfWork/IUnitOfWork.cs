using CleanArch.Application.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        Task<int> SaveAsync();
        public INoteRepository noteRepository { get; set; }
        public ITagRepository tagRepository { get; set; }
    }
}
