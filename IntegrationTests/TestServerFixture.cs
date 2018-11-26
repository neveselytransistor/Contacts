using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;
using Contacts;
using Microsoft.Extensions.Configuration;
using Xunit;

namespace IntegrationTests
{
    public class TestServerFixture
    {
        private readonly TestServer _server;
        private readonly HttpClient _client;

        public TestServerFixture()
        {
            var cb = new ConfigurationBuilder()
                     .AddJsonFile("appsettings.json", false, false)
                     .AddJsonFile("appsettings.Test.json", false, false)
                     .Build();
            var builder = new WebHostBuilder()
                          .UseStartup<Startup>()
                          .UseConfiguration(cb)
                          .UseEnvironment("Test");

            _server = new TestServer(builder);
            _client = _server.CreateClient();
        }

        [Fact]
        public async Task ReturnResult()
        {
            //var response = await _client.GetAsync("/");
            //response.EnsureSuccessStatusCode();
            //var responseString = await response.Content.ReadAsStringAsync();
            //Assert.Equal("", responseString);
        }
    }
}