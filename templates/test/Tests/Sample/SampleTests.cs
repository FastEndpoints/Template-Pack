namespace Tests.Sample;

public class AppFixture(IMessageSink s) : AppFixture<Program>(s) {}

public class SampleTests(AppFixture a, ITestOutputHelper o) : TestClass<AppFixture>(a, o)
{
    [Fact]
    public void Sample_Test()
    {
        (1 + 1).Should().Be(2);
    }
}