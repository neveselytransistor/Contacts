using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Services
{
    public interface IUserService
    {
        Task<bool> IsUserFoundByEmail(string email);

        Task<User> FindUser(string email, string password);

        Task InsertUser(User user);
    }
}