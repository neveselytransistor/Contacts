
using Contacts;
using Contacts.Models;
using Contacts.Services;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Moq;
using Xunit;

namespace UnitTests
{
    public class ServiceTests
    {
        [Fact(Skip = "Не дописан")]
        public async void VerifyNewContactIsAdded()
        {
            var contextMock = new Mock<ApplicationContext>();

            var newContact = new Contact
            {
                Name = "TestContact",
                Phone = "123456"
            };

            //contextMock.Setup(x => x.Contacts.AddAsync(It.IsAny<Contact>())).Returns()
            
            var contactService = new ContactService(contextMock.Object);
            await contactService.AddContact(newContact);

            //contextMock.Verify(x => x.Contacts.AddAsync(newContact), Times.AtLeastOnce);
        }
    }
}
