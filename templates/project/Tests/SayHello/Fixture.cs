namespace Tests.SayHello;

public class Fixture(IMessageSink s) : TestFixture<Program>(s)
{
    protected override Task SetupAsync()
    {
        // place one-time setup for the test-class here
        return Task.CompletedTask;
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        // do test service registration here
    }

    protected override Task TearDownAsync()
    {
        // do cleanups here
        return Task.CompletedTask;
    }
}