using Microsoft.AspNetCore.Mvc.Testing;
using Xunit.Abstractions;
using Xunit.Priority;
namespace WebApiXunit3.Test
{
    [TestCaseOrderer(PriorityOrderer.Name, PriorityOrderer.Assembly)]
    public class UnitTest1: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly ITestOutputHelper output;
        private readonly HttpClient _client;
        public UnitTest1(WebApplicationFactory<Program> factory, ITestOutputHelper output)
        {
            _client = factory.CreateClient();
            this.output = output;
        }

        [Theory, InlineData("/weatherforecast")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType(string url)
        {
             // Act
            var response = await _client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("application/json; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }

        [Theory, InlineData("/helloworld")]
        public async Task Get_EndpointsReturnSuccessAndCorrectContentType2(string url)
        {
            // Act
            var response = await _client.GetAsync(url);
            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("text/plain; charset=utf-8", response.Content.Headers.ContentType!.ToString());
        }
    }
}
