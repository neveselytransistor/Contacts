using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;
using Contacts.Services;
using Microsoft.AspNetCore.Mvc;
using Serilog;

namespace Contacts.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        /// <summary>
        /// Возвращает список контактов для текущего пользователя
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ViewResult> ContactList()
        {
            var userId = GetUserId();
            var contacts = await _contactService.GetContacts(userId);
            return View(contacts);
        }

        /// <summary>
        /// Обновляет контакт
        /// </summary>
        /// <param name="contact">Контакт с формы</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> UpdateContact([FromForm] Contact contact)
        {
            await _contactService.UpdateContact(contact);

            return RedirectToAction("ContactList");
        }

        /// <summary>
        /// Возвращает представление для редактирования контакта
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ViewResult> EditContact(int id)
        {
            var contact = await _contactService.FindContact(id);
            return View(contact);
        }

        /// <summary>
        /// Добавляет новый контакт
        /// </summary>
        /// <param name="contact">Данные нового контакта</param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddContact([FromForm] Contact contact)
        {
            contact.UserId = GetUserId();
            await _contactService.AddContact(contact);

            return RedirectToAction("ContactList");
        }

        /// <summary>
        /// Возвращает представление контакта
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        /// <summary>
        /// Удаляет указанный контакт
        /// </summary>
        /// <param name="id">Идентификатор контакта</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteContact(id);

            return RedirectToAction("ContactList");
        }

        /// <summary>
        /// Получает Id пользователя из контекста
        /// </summary>
        /// <returns></returns>
        private int GetUserId()
        {
            var claims = HttpContext.User.Claims;
            var userId = Int32.Parse(claims.First(x => x.Type == "userId").Value);
            return userId;
        }
    }
}