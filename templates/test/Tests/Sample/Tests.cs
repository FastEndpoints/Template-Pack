namespace Tests.Sample;

public class App : AppFixture<Program>;

public class Tests : TestClass<App>
{
    [Fact]
    public void Sample_Test()
    {
        (1 + 1).ShouldBe(2);
    }
}