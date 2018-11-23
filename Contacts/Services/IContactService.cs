using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Services
{
    public interface IContactService
    {
        Task AddContact(Contact contact);

        Task UpdateContact(Contact contact);

        Task DeleteContact(int id);

        Task<List<Contact>> GetContacts(int userId);

        Task<Contact> FindContact(int id);
    }
}