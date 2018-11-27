using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Repositories
{
    public interface IContactRepository
    {
        Task AddAsync(Contact contact);
        Task DeleteAsync(int id);
        Task<Contact> FindAsync(int id);
        Task<List<Contact>> GetAsync(int userId);
        Task UpdateAsync(Contact contact);
    }
}