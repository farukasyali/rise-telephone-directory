using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.Extensions.Options;
using PhoneBook.Services.ReportPublisher.Api.Services.Abstract;
using PhoneBook.Shared.Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace PhoneBook.Services.ReportPublisher.Api.Services
{
    public class ReportService : IReportService
    {
        private readonly HttpClient _client;
        private readonly ServiceSettings serviceSettings;
        private readonly ReportFileSettings reportFileSettings;
        HubConnection connection;

        public ReportService(HttpClient client, IOptionsSnapshot<ServiceSettings> serviceOptions, IOptionsSnapshot<ReportFileSettings> fileOptions)
        {
            serviceSettings = serviceOptions.Value;
            reportFileSettings = fileOptions.Value;
            _client = client;
            _client.BaseAddress = new Uri(serviceSettings.ReportApiUrl);
            connection = new HubConnectionBuilder()
                .WithUrl($"{serviceSettings.SignalRHub}/reportHub")
                .Build();

            connection.Closed += async (error) =>
            {
                await Task.Delay(new Random().Next(0, 5) * 1000);
                await connection.StartAsync();
            };
        }

        public async Task<string> SaveReportData(Guid reportId, string data)
        {

            var content = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("value", data),
                new KeyValuePair<string, string>("id", reportId.ToString())
            });

            var response = await _client.PostAsync($"api/Report/saveReportData", content);

            if (!response.IsSuccessStatusCode)
            {
                return "{'error': 'Servis çağrısından hata alındı.'}";
            }

            var responseSuccess = await response.Content.ReadAsStringAsync();

            return responseSuccess;
        }

        public async Task SendSignalRMessage(Guid id)
        {
            await connection.StartAsync();
            await connection.InvokeAsync("SendReportReadyMessage", id.ToString());
        }
    }
}
