using CleanArch.Application.Interfaces.Context;
using CleanArch.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Context
{
    public class CleanArchContext : DbContext, IApplicationDbContext
    {
        public CleanArchContext(DbContextOptions options):base(options)
        {

        }

        public CleanArchContext()
        {
            //Needs for Entity Framework
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
