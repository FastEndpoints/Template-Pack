using Microsoft.AspNetCore.Hosting;

namespace Tests.SayHello;

public class App : AppFixture<Program>
{
    protected override ValueTask SetupAsync()
    {
        // place one-time setup for the fixture here
        return ValueTask.CompletedTask;
    }

    protected override void ConfigureApp(IWebHostBuilder a)
    {
        // do host builder configuration here
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        // do test service registration here
    }

    protected override ValueTask TearDownAsync()
    {
        // do cleanups here
        return ValueTask.CompletedTask;
    }
}