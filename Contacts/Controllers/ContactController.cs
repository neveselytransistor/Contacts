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
        private readonly ILogger _logger;

        public ContactController(IContactService contactService, ILogger logger)
        {
            _contactService = contactService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ViewResult> ContactList()
        {
            var userId = GetUserId();
            var contacts = await _contactService.GetContacts(userId);
            return View(contacts);
        }

        [HttpPost]
        public async Task<IActionResult> UpdateContact([FromForm] Contact contact)
        {
            await _contactService.UpdateContact(contact);

            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public async Task<ViewResult> EditContact(int id)
        {
            var contact = await _contactService.FindContact(id);
            return View(contact);
        }

        [HttpPost]
        public async Task<IActionResult> AddContact([FromForm] Contact contact)
        {
            contact.UserId = GetUserId();
            await _contactService.AddContact(contact);

            return RedirectToAction("ContactList");
        }

        [HttpGet]
        public IActionResult CreateContact()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            await _contactService.DeleteContact(id);

            return RedirectToAction("ContactList");
        }

        private int GetUserId()
        {
            var claims = HttpContext.User.Claims;
            var userId = Int32.Parse(claims.First(x => x.Type == "userId").Value);
            return userId;
        }
    }
}