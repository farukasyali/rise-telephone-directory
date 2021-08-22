using MassTransit;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using PhoneBook.Services.ReportPublisher.Api.Consumers;
using PhoneBook.Services.ReportPublisher.Api.Services;
using PhoneBook.Services.ReportPublisher.Api.Services.Abstract;
using PhoneBook.Shared.Models;

namespace PhoneBook.Services.ReportPublisher.Api
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
            services.Configure<ServiceSettings>(Configuration.GetSection("ServiceSettings"));
            services.Configure<ReportFileSettings>(Configuration.GetSection("ReportFileSettings"));
            services.AddHttpClient<IReportService, ReportService>();
            services.AddHttpClient<IPersonService, PersonService>();

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "PhoneBook.Services.ReportPublisher.Api", Version = "v1" });
            });

            services.AddMassTransit(x =>
            {
                x.AddConsumer<CreateReportMessageCommandConsumer>();
                // Default Port : 5672
                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(Configuration["RabbitMQUrl"], "/", host =>
                    {
                        host.Username("guest");
                        host.Password("guest");
                    });

                    cfg.ReceiveEndpoint("create-report-service", e =>
                    {
                        e.ConfigureConsumer<CreateReportMessageCommandConsumer>(context);
                    });
                    
                });
            });

            services.AddMassTransitHostedService();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "PhoneBook.Services.ReportPublisher.Api v1"));
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
