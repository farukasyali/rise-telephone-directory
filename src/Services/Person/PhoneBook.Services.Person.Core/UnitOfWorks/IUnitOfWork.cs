using PhoneBook.Services.Person.Core.Repositories;
using System.Threading.Tasks;

namespace PhoneBook.Services.Person.Core.UnitOfWorks
{
    public interface IUnitOfWork
    {
        IPersonRepository Persons { get; }

        IPersonContactRepository PersonContacts { get; }

        Task CommitAsync();

        void Commit();
    }
}
