using MassTransit;
using PhoneBook.Services.ReportPublisher.Api.Services.Abstract;
using PhoneBook.Shared.Messages;
using System.Threading.Tasks;

namespace PhoneBook.Services.ReportPublisher.Api.Consumers
{
    public class CreateReportMessageCommandConsumer : IConsumer<CreateReportMessageCommand>
    {
        private readonly IReportService _reportService;
        private readonly IPersonService _personService;


        public CreateReportMessageCommandConsumer(IReportService reportService, IPersonService personService)
        {
            _reportService = reportService;
            _personService = personService;
        }

        public async Task Consume(ConsumeContext<CreateReportMessageCommand> context)
        {
            var data = await _personService.GetReportData();
            var res = await _reportService.SaveReportData(context.Message.ReportId, data);
            if (res.Contains("error") == false)
                await _reportService.SendSignalRMessage(context.Message.ReportId);
            return;
        }
    }
}
