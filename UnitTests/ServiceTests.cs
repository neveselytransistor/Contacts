
using Contacts.Models;
using Contacts.Repositories;
using Contacts.Services;
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

        [Fact]
        public async void VerifyContactIsDeleted()
        {
            var repositoryMock = new Mock<IContactRepository>();
            var service = new ContactService(repositoryMock.Object);
            var id = 1;

            await service.DeleteContact(id);

            repositoryMock.Verify(r => r.DeleteAsync(It.Is<int>(i => i == id)), Times.Once);
        }

        [Fact]
        public async void VerifyContactIsUpdated()
        {
            var repositoryMock = new Mock<IContactRepository>();
            var service = new ContactService(repositoryMock.Object);
            var newContact = new Contact
            {
                Id = 1,
                UserId = 1,
                Name = "Name",
                Phone = "Phone"
            };

            await service.UpdateContact(newContact);

            repositoryMock.Verify(r => r.UpdateAsync(It.Is<Contact>(c => c.UserId == 0 && 
                                                                         c.Id == newContact.Id && 
                                                                         c.Name == newContact.Name)), Times.Once);
        }

    }
}