using Microsoft.Extensions.Options;
using PhoneBook.Services.ReportPublisher.Api.Services.Abstract;
using PhoneBook.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace PhoneBook.Services.ReportPublisher.Api.Services
{
    public class PersonService : IPersonService
    {

        private readonly HttpClient _client;
        private readonly ServiceSettings serviceSettings;

        public PersonService(HttpClient client, IOptionsSnapshot<ServiceSettings> serviceOptions)
        {
            _client = client;
            serviceSettings = serviceOptions.Value;
            _client.BaseAddress = new Uri(serviceSettings.PersonApiUrl);
        }

        public async Task<string> GetReportData()
        {
            var response = await _client.GetAsync($"api/Person/getReportData");

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }
    }
}
