using System.Text.Json;
using Microsoft.AspNetCore.Hosting;

namespace Tests.SayHello;

public class App : AppFixture<Program>
{
    protected override ValueTask SetupAsync()
    {
        // place one-time setup for the fixture here.
        return ValueTask.CompletedTask;
    }

    protected override void ConfigureApp(IWebHostBuilder a)
    {
        // do host builder configuration here.
        // only called when running under WAF mode.
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        // do test service registration here.
        // only called when running under WAF mode.
    }

    protected override ValueTask ConfigureAotTargetAsync(AotTargetOptions o)
    {
        // settings for building and running a native aot black-box instance.
        // all settings are optional. customization only needed if auto management fails.

        o.BuildTimeoutMinutes = 1;
        o.HealthEndpointPath = "/healthy";
        o.ReadyTimeoutSeconds = 5;
        o.EnvironmentVariables["ASPNETCORE_ENVIRONMENT"] = "Testing";

        // make routeless test helpers use the same serializer settings as the app
        new Config().Serializer.Options.PropertyNamingPolicy = JsonNamingPolicy.CamelCase;

        return ValueTask.CompletedTask;
    }

    protected override ValueTask TearDownAsync()
    {
        // do cleanups here
        return ValueTask.CompletedTask;
    }
}