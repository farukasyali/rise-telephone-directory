using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PhoneBook.Services.Person.Core.Repositories;
using PhoneBook.Services.Person.Core.Services;
using PhoneBook.Services.Person.Core.UnitOfWorks;
using PhoneBook.Services.Person.Data;
using PhoneBook.Services.Person.Data.Repositories.EntityFramework;
using PhoneBook.Services.Person.Data.UnitOfWorks;
using PhoneBook.Services.Person.Service.Services;

namespace PhoneBook.Services.Person.Api
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
           
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IRepository<>), typeof(EfRepository<>));
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IPersonContactService, PersonContactService>();

            services.AddAutoMapper(typeof(Startup));

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.Services.Person.Api", Version = "v1" });
            });

            services.AddDbContext<PhoneBookDbContext>(options =>
            {
                options.UseNpgsql(Configuration["ConnectionStrings:PostgresqlConnection"].ToString(), b => b.MigrationsAssembly("PhoneBook.Services.Person.Api"));
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook.Services.Person.Api v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
