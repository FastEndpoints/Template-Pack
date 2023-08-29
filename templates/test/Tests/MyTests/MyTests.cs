namespace MyTests;

public class MyTests : TestBase
{
    public MyTests(AppFixture fixture) : base(fixture) { }

    [Fact]
    public void My_First_Test()
    {
        (1 + 1).Should().Be(2);
    }
}