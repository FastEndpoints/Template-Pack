namespace Tests.Sample;

public class MyFixture(IMessageSink s) : TestFixture<Program>(s) {}

public class SampleTests(MyFixture f, ITestOutputHelper o) : TestClass<MyFixture>(f, o)
{
    [Fact]
    public void Sample_Test()
    {
        (1 + 1).Should().Be(2);
    }
}