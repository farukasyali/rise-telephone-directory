using PhoneBook.Services.PersonApi.Repositories.Abstract;
using System.Threading.Tasks;

namespace PhoneBook.Services.PersonApi.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }

        IPersonContactRepository PersonContacts { get; }

        Task CommitAsync();

        void Commit();
    }
}
