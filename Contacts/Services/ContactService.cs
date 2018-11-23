using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Contacts.Services
{
    public class ContactService : IContactService
    {
        private readonly ApplicationContext _context;

        public ContactService(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddContact(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateContact(Contact newContact)
        {
            var contact = new Contact
            {
                Id = newContact.Id,
                Name = newContact.Name,
                Phone = newContact.Phone
            };
            _context.Attach(contact);
            _context.Entry(contact).Property(u => u.Name).IsModified = true;
            _context.Entry(contact).Property(u => u.Phone).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetContacts(int userId)
        {
            return await _context.Contacts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task DeleteContact(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> FindContact(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}