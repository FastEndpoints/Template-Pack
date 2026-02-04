namespace SayHello;

sealed class Endpoint : Endpoint<Request, Response>
{
    public override void Configure()
    {
        Post("/api/hello");
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        await Send.OkAsync(
            new()
            {
                Message = $"Hello {r.FirstName} {r.LastName}..."
            });
    }
}