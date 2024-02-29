namespace MongoWebApiStarter.Notifications;

sealed class SendSmsMessage : ICommand
{
    public string Mobile { get; set; }
    public string Body { get; set; }
}

sealed class SendSmsMessageHandler : ICommandHandler<SendSmsMessage>
{
    public Task ExecuteAsync(SendSmsMessage cmd, CancellationToken c)

        // TODO: implement sms gateway client
        => Task.CompletedTask;
}