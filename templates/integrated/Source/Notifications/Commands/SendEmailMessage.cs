using Amazon.SimpleEmailV2;

namespace MyProject.Notifications;

public sealed class SendEmailMessage : ICommand
{
    public string ToName { get; init; }
    public string ToEmail { get; init; }
    public string Subject { get; init; }
    public string Body { get; init; }
}

sealed class SendEmailMessageHandler(IAmazonSimpleEmailServiceV2 sesClient, IWebHostEnvironment env, IConfiguration cfg) : ICommandHandler<SendEmailMessage>
{
    readonly string _fromName = cfg["Email:FromName"]!;
    readonly string _fromEmail = cfg["Email:FromEmail"]!;

    public Task ExecuteAsync(SendEmailMessage cmd, CancellationToken c)
    {
        if (env.IsDevelopment())
            return Task.CompletedTask;

        return sesClient.SendEmailAsync(
            request: new()
            {
                FromEmailAddress = $"{_fromName}<{_fromEmail}>",
                Destination = new()
                {
                    ToAddresses = [$"{cmd.ToName}<{cmd.ToEmail}>"]
                },
                Content = new()
                {
                    Simple = new()
                    {
                        Subject = new() { Data = cmd.Subject },
                        Body = new() { Html = new() { Data = cmd.Body } }
                    }
                }
            },
            cancellationToken: c);
    }
}