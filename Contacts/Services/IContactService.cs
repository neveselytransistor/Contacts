using System.Collections.Generic;
using System.Threading.Tasks;
using Contacts.Models;

namespace Contacts.Services
{
    /// <summary>
    /// Предоставляет сервисы для работы с контактам
    /// </summary>
    public interface IContactService
    {
        /// <summary>
        /// Добавляет новый контакт
        /// </summary>
        /// <param name="contact">Данные контакта</param>
        /// <returns></returns>
        Task AddContact(Contact contact);

        /// <summary>
        /// Обновляет контакт
        /// </summary>
        /// <param name="contact">Данные нового контакта</param>
        /// <returns></returns>
        Task UpdateContact(Contact contact);

        /// <summary>
        /// Удаляет указанный контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <returns></returns>
        Task DeleteContact(int id);

        /// <summary>
        /// Получает список контактов для указанного пользователя
        /// </summary>
        /// <param name="userId">Идентификатор пользователя</param>
        /// <returns></returns>
        Task<List<Contact>> GetContacts(int userId);

        /// <summary>
        /// Получает указанный контакт
        /// </summary>
        /// <param name="id">Индентификатор контакта</param>
        /// <returns></returns>
        Task<Contact> FindContact(int id);
    }
}