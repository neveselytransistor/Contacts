using System.Threading;
using Contacts;
using Contacts.Models;
using Contacts.Repositories;
using Contacts.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Xunit;

namespace UnitTests
{
    public class ServiceTests
    {
        [Fact]
        public async void VerifyNewContactIsAdded()
        {
            var repositoryMock = new Mock<IContactRepository>();
            var service = new ContactService(repositoryMock.Object);
            var newContact = new Contact
            {
                Name = "TestContact",
                Phone = "123456"
            };

            await service.AddContact(newContact);

            repositoryMock.Verify(r => r.AddAsync(It.Is<Contact>(c => ReferenceEquals(newContact, c))), Times.Once);
        }
    }
}