using CleanArch.Application.Interfaces.Context;
using CleanArch.Domain.Entities;
using CleanArch.Persistence.Context.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Context
{
    public class CleanArchContext : DbContext, IApplicationDbContext
    {
        public IConfiguration configuration
        {
            get
            {
                var configurationBuilder = new ConfigurationBuilder();
                configurationBuilder.AddJsonFile("appsettings.json");
                return configurationBuilder.Build();
            }
        }

        public CleanArchContext(DbContextOptions<CleanArchContext> options) : base(options) { }
        public CleanArchContext() { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new NoteConfiguration());
            modelBuilder.ApplyConfiguration(new TagConfiguration());
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(configuration.GetConnectionString("CleanArchContext"));

        }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Note> Notes { get; set; }
    }
}
