using PhoneBook.Services.Report.Core.Repositories;
using System.Threading.Tasks;

namespace PhoneBook.Services.Report.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IReportsRepository Report { get; }

        Task CommitAsync();

        void Commit();
    }
}
