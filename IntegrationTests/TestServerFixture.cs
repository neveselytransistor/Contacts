using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contacts;
using Xunit;

namespace IntegrationTests
{
    public class TestServerFixture
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestServerFixture()
        {
            var builder = new WebHostBuilder()
                          .UseStartup<Startup>()
                          .UseSetting("ConnectionStrings:DefaultConnection", "Data Source = testdata.db");

            _server = new TestServer(builder);
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task GetContactsTest()
        {
            var response = await _client.GetAsync("/Contact/ContactList");

            var path = response.Headers.Location.LocalPath;
            var query = response.Headers.Location.Query;
            Assert.Equal("/Auth/Login", path);
            Assert.Equal("?ReturnUrl=%2FContact%2FContactList", query);
        }

        [Fact(Skip = "Переделать")]
        public async Task LoginTest()
        {
            var email = "Tom@mail.ru";
            var password = "1234";

            var content = new StringContent($"email={email}&password={password}",
                                            Encoding.UTF8,
                                            "application/x-www-form-urlencoded");
            var response = await _client.PostAsync("/Auth/Login", content);
        

            Assert.Equal("?ReturnUrl=%2FContact%2FContactList", response.Headers.Location.Query);
        }
    }
}