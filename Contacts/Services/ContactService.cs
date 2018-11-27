using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;
using Contacts.Repositories;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly IContactRepository _contactRepository;

        public ContactService(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task AddContact(Contact contact)
        {
            await _contactRepository.AddAsync(contact);
        }

        public async Task UpdateContact(Contact newContact)
        {
            var contact = new Contact
            {
                Id = newContact.Id,
                Name = newContact.Name,
                Phone = newContact.Phone
            };
            await _contactRepository.UpdateAsync(contact);
        }

        public async Task<List<Contact>> GetContacts(int userId)
        {
            return await _contactRepository.GetAsync(userId);
        }

        public async Task DeleteContact(int id)
        {
            await _contactRepository.DeleteAsync(id);
        }

        public async Task<Contact> FindContact(int id)
        {
            return await _contactRepository.FindAsync(id);
        }
    }
}