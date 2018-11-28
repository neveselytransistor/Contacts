using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Services
{
    /// <summary>
    /// Предоставляет методы для работы с пользователем
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// Определяет, найден ли пользователь в БД по email
        /// </summary>
        /// <param name="email">Email пользователя</param>
        /// <returns></returns>
        Task<bool> IsUserFoundByEmail(string email);

        /// <summary>
        /// Возвращает пользователя по email и паролю
        /// </summary>
        /// <param name="email">Email</param>
        /// <param name="password">Пароль</param>
        /// <returns></returns>
        Task<User> FindUser(string email, string password);

        /// <summary>
        /// Добавляет в БД нового пользователя
        /// </summary>
        /// <param name="user">Данные пользователя</param>
        /// <returns></returns>
        Task InsertUser(User user);
    }
}