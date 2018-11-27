using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationContext _context;

        public ContactRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Contact contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Contact contact)
        {
            _context.Attach(contact);
            _context.Entry(contact).Property(u => u.Name).IsModified = true;
            _context.Entry(contact).Property(u => u.Phone).IsModified = true;
            await _context.SaveChangesAsync();
        }

        public async Task<List<Contact>> GetAsync(int userId)
        {
            return await _context.Contacts.Where(x => x.UserId == userId).ToListAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            _context.Contacts.Remove(contact);
            await _context.SaveChangesAsync();
        }

        public async Task<Contact> FindAsync(int id)
        {
            return await _context.Contacts.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}