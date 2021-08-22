using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;

namespace PhoneBook.Web.Hubs
{
    public class ReportHub : Hub
    {
        public async Task SendReportReadyMessage(Guid reportId)
        {
            await Clients.All.SendAsync("reportCreated", reportId.ToString());
        }
    }
}
