using Microsoft.Extensions.Options;
using PhoneBook.Shared.Models;
using PhoneBook.Web.Models;
using PhoneBook.Web.Services.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Web.Services
{
    public class ReportService : IReportService
    {

        private readonly HttpClient _client;
        private readonly ServiceSettings serviceSettings;


        public ReportService(HttpClient client, IOptionsSnapshot<ServiceSettings> serviceOptions)
        {
            serviceSettings = serviceOptions.Value;
            _client = client;
            _client.BaseAddress = new Uri(serviceSettings.ReportApiUrl);
        }

        public async Task<string> GetList()
        {
            var response = await _client.GetAsync("api/Report/getall/");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> GetReportData(Guid id)
        {
            var response = await _client.GetAsync($"api/Report/getReportData?id={id}");

            if (!response.IsSuccessStatusCode)
            {
                return null;
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task<string> SaveReport()
        {
            var data = new StringContent(string.Empty, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("api/Report/saveReport/", data);

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }


    }
}
