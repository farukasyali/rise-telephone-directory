using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PhoneBook.Web.Models;
using PhoneBook.Web.Services;
using PhoneBook.Web.Services.Abstract;
using System;

namespace PhoneBook.Web.Extentions
{
    public static class ServiceExtention
    {
        public static void AddHttpClientServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddHttpClient<IPersonService, PersonService>();

            services.AddHttpClient<IReportService, ReportService>();
        }
    }
}
