using CleanArch.Application.Extensions;
using CleanArch.Persistence.Extensions;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using NSwag;

namespace CleanArch.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddApplicationServices();
            services.AddPersistenceServices(Configuration);

            services.AddControllers();
            services.AddSwaggerDocument(config =>
                config.PostProcess = ( settings => {
                    settings.Info.Title = "Clean Architecture";
                    settings.Info.Description = "Clean Architecture API Documentation";
                    settings.Info.Contact = new OpenApiContact
                    {
                        Email = "oabdullahozturk@yandex.com",
                        Name = "Abdullah Öztürk",
                        Url = "https://abdullahozturk.live",
                    };
                    settings.Info.Version = "v1";
                }
            ));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseOpenApi();

            app.UseSwaggerUi3();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
