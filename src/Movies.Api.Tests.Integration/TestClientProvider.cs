using System;
using System.Net.Http;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Movies.Api.DAL;

namespace Movies.Api.Tests.Integration
{
    public class TestClientProvider : IDisposable
    {
        private readonly TestServer _server;

        public HttpClient Client { get; }

        public TestClientProvider()
        {
            var builder = WebHost.CreateDefaultBuilder()
                .UseStartup<Startup>()
                .UseEnvironment("Development")
                .ConfigureServices(
                    s => s.AddDbContext<ApiContext>(opt => opt.UseInMemoryDatabase("Development")));

            _server = new TestServer(builder);

            Client = _server.CreateClient();
        }

        public void Dispose()
        {
            _server?.Dispose();
            Client?.Dispose();
        }
    }
}
