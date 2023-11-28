using Microsoft.Extensions.DependencyInjection;

namespace WebApi.IntegrationTests.Configuration;

public class IntegrationTest
{
    protected HttpClient TestHttpClient { get; }
    protected IServiceScope Scope { get; set; }

    protected IntegrationTest()
    {
        var appFactory = new CustomWebApplicationFactory();
        TestHttpClient = appFactory.CreateClient();
        Scope = appFactory.Services.CreateScope();
    }

}