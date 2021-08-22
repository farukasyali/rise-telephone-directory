using AutoMapper;
using PhoneBook.Services.Report.Core.UnitOfWorks;
using PhoneBook.Services.Report.Core.Dtos;
using PhoneBook.Services.Report.Core.Models;
using PhoneBook.Services.Report.Core.Repositories;
using System;
using System.Threading.Tasks;
using PhoneBook.Services.Report.Core.Services;
using System.Collections.Generic;
using System.Linq;

namespace PhoneBook.Services.Report.Service.Services
{
    public class ReportService : Service<Reports>, IReportService
    {

        private readonly IMapper _mapper;

        public ReportService(IMapper mapper, IUnitOfWork unitOfWork, IRepository<Reports> repository) : base(unitOfWork, repository)
        {
            _mapper = mapper;
        }

        public async Task<ReportDto> AddAsync()
        {
            var entity = new Reports()
            {
                Id = Guid.NewGuid(),
                RequestDate = DateTime.Now,
                Status = "Hazırlanıyor"
            };

            await _unitOfWork.Report.AddAsync(entity);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<ReportDto>(entity);

        }

        public async Task<IEnumerable<ReportDto>> GetListAsync()
        {
            var result = await _unitOfWork.Report.GetAllAsync();

            result = result.OrderByDescending(a => a.RequestDate).ToList();

            return _mapper.Map<List<ReportDto>>(result);
        }
    }
}
