using System.Collections.Generic;

namespace Contacts.Models
{
    public class User
    {
        public string Name { get; set; }

        public string Surname { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public int Id { get; set; }

        public List<Contact> Contacts { get; set; }
    }
}