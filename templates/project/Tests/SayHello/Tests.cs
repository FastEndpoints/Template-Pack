using SayHello;

namespace Tests.SayHello;

public class Tests(Fixture f, ITestOutputHelper o) : TestClass<Fixture>(f, o)
{
    [Fact, Priority(1)]
    public async Task Invalid_User_Input()
    {
        var (rsp, res) = await Fixture.Client.POSTAsync<Endpoint, Request, ErrorResponse>(new()
        {
            FirstName = "x",
            LastName = "y"
        });

        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res!.Errors.Count.Should().Be(2);
        res.Errors.Keys.Should().Equal("firstName", "lastName");
    }

    [Fact, Priority(2)]
    public async Task Valid_User_Input()
    {
        var (rsp, res) = await Fixture.Client.POSTAsync<Endpoint, Request, Response>(new()
        {
            FirstName = "Mike",
            LastName = "Kelso"
        });

        rsp.StatusCode.Should().Be(HttpStatusCode.OK);
        res!.Message.Should().Be("Hello Mike Kelso...");
    }
}