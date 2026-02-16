using SayHello;

namespace Tests.SayHello;

public class Tests(App App) : TestBase<App>
{
    [Fact, Priority(1)]
    public async Task Invalid_User_Input()
    {
        var (rsp, res) = await App.Client.POSTAsync<Endpoint, Request, ProblemDetails>(
                             new()
                             {
                                 FirstName = "x",
                                 LastName = "y"
                             });

        rsp.StatusCode.ShouldBe(HttpStatusCode.BadRequest);
        res.Errors.Count().ShouldBe(2);
        res.Errors.Select(e => e.Name).ShouldBe(["firstName", "lastName"]);
    }

    [Fact, Priority(2)]
    public async Task Valid_User_Input()
    {
        var (rsp, res) = await App.Client.POSTAsync<Endpoint, Request, Response>(
                             new()
                             {
                                 FirstName = "Mike",
                                 LastName = "Kelso"
                             });

        rsp.StatusCode.ShouldBe(HttpStatusCode.OK);
        res.Message.ShouldBe("Hello Mike Kelso...");
    }
}