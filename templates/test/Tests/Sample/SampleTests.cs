namespace Tests.Sample;

public class MyFixture : TestFixture<Program>
{
    public MyFixture(IMessageSink s) : base(s) { }
}

public class SampleTests : TestClass<MyFixture>
{
    public SampleTests(MyFixture f, ITestOutputHelper o) : base(f, o) { }

    [Fact]
    public void Sample_Test()
    {
        (1 + 1).Should().Be(2);
    }
}