using Amazon.SimpleEmailV2;

namespace MyProject.Tests;

public class App : AppFixture<Program>
{
    protected override void ConfigureApp(IWebHostBuilder a)
    {
        //only needed when tests are not in a separate project
        a.UseContentRoot(Directory.GetCurrentDirectory());
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        s.AddSingleton<IAmazonSimpleEmailServiceV2, FakeSesClient>();
    }
}