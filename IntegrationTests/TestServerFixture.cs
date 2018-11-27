using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;

using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Contacts;
using Microsoft.Net.Http.Headers;
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

        [Fact(/*Skip = "Переделать"*/)]
        public async Task LoginTest()
        {
            var loginFormResponse = await _client.GetAsync("/Auth/Login");

            loginFormResponse.EnsureSuccessStatusCode();

            var token = await AntiForgeryHelper.ExtractAntiForgeryToken(loginFormResponse);
            var form = new Dictionary<string, string>
            {
                ["email"] = "Tom@mail.ru",
                ["password"] = "1234",
                ["__RequestVerificationToken"] = token
            };

            var request = new HttpRequestMessage(HttpMethod.Post, "/Auth/Login")
            {
                Content = new FormUrlEncodedContent(form)
            };

            if (loginFormResponse.Headers.TryGetValues("Set-Cookie", out IEnumerable<string> values))
            {
                foreach (var cookieHeaderValue in SetCookieHeaderValue.ParseList(values.ToList()).ToList())
                {
                    var cookie = new CookieHeaderValue(cookieHeaderValue.Name.Value, 
                                                       cookieHeaderValue.Value.Value).ToString();
                    request.Headers.Add("Cookie", cookie);
                }
            }

            var response = await _client.SendAsync(request);

            response.EnsureSuccessStatusCode();
            Assert.Equal("/", response.Headers.Location.LocalPath);
        }
    }
}