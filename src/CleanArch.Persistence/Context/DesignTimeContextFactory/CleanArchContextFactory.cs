using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArch.Persistence.Context.DesignTimeContextFactory
{
    public class CleanArchContextFactory : IDesignTimeDbContextFactory<CleanArchContext>
    {
        public CleanArchContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<CleanArchContext>();
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-2QF0S4K;Initial Catalog=CleanArchDb;Integrated Security=True;Connect Timeout=30;");
            return new CleanArchContext(optionsBuilder.Options);
        }
    }
}
