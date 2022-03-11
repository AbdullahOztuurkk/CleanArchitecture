using CleanArch.Application.Interfaces.Context;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Context.Configurations;
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
        public CleanArchContext(DbContextOptions options) : base(options) { }
        public CleanArchContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration<Note>(new NoteConfiguration());
            modelBuilder.ApplyConfiguration<Tag>(new TagConfiguration());
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
