using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Application.Interfaces.Context
{
    public interface IApplicationDbContext
    {
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
