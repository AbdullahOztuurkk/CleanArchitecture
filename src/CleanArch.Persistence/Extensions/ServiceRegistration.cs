using CleanArch.Persistence.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using CleanArch.Persistence.Repositories;
using CleanArch.Application.Interfaces.Repositories;

namespace CleanArch.Persistence.Extensions
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
        {
            services.AddDbContext<CleanArchContext>(options => options.UseSqlServer(configuration.GetConnectionString("CleanArchContext")));
            services.AddScoped<INoteRepository, NoteRepository>();
            services.AddScoped<ITagRepository, TagRepository>();
        }
    }
}
