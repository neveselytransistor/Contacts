using Contacts.Models;
using Microsoft.EntityFrameworkCore;

namespace Contacts
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new []
                {
                    new User { Id=1, Name="Tom", Email = "tom@mail.ru", Password = "1234"},
                    new User { Id=2, Name="Alice", Email = "alice@mail.ru", Password = "1234"},
                    new User { Id=3, Name="Sam", Email = "sam@mail.ru", Password = "1234"}
                });
            modelBuilder.Entity<Contact>().HasData(
                new []
                {
                    new Contact {Id = 1, Name = "Tom's friend", Phone = "123456789", UserId = 1},
                    new Contact {Id = 2, Name = "Alice's friend", Phone = "123456789", UserId = 2},
                    new Contact {Id = 3, Name = "Sam's friend", Phone = "123456789", UserId = 3},
                });
            base.OnModelCreating(modelBuilder);
        }
    }
}