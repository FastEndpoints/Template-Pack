using SayHello;

namespace EndpointTests;

public class SayHelloTests : TestBase
{
    public SayHelloTests(AppFixture fixture) : base(fixture) { }

    [Fact]
    public async Task Invalid_User_Input()
    {
        var (rsp, res) = await App.GuestClient.POSTAsync<Endpoint, Request, ErrorResponse>(new()
        {
            FirstName = "x",
            LastName = "y"
        });

        rsp.StatusCode.Should().Be(HttpStatusCode.BadRequest);
        res!.Errors.Count.Should().Be(2);
        res.Errors["firstName"][0].Contains("length");
        res.Errors["lastName"][0].Contains("length");
    }

    [Fact, Priority(2)]
    public async Task Valid_User_Input()
    {
        var (rsp, res) = await App.GuestClient.POSTAsync<Endpoint, Request, Response>(new()
        {
            FirstName = "Mike",
            LastName = "Kelso"
        });

        rsp.StatusCode.Should().Be(HttpStatusCode.OK);
        res!.Message.Should().Be("Hello Mike Kelso...");
    }
}