namespace Members.Signup;

sealed class Endpoint : Endpoint<Request, Response, Mapper>
{
    public override void Configure()
    {
        Post("members/signup");
        PreProcessor<DuplicateInfoChecker>();
        AllowAnonymous();
    }

    public override async Task HandleAsync(Request r, CancellationToken c)
    {
        var member = Map.ToEntity(r);

        member.MemberNumber = await DB.NextSequentialNumberAsync<Dom.Member>(c) + 100;
        member.SignupDate = DateOnly.FromDateTime(DateTime.UtcNow);

        await member.SaveAsync(cancellation: c);

        //todo: send email to member

        await new Notification
            {
                Type = NotificationType.ReviewNewMember,
                SendEmail = true,
                SendSms = false,
                ToEmail = Config["Email:Administrator"]!,
                ToName = "MyProject Admin"
            }.Merge("{MemberName}", $"{member.FirstName} {member.LastName}")
             .Merge("{LoginLink}", "https://MyProject.com/admin/login")
             .Merge("{TrackingId}", member.ID)
             .AddToSendingQueueAsync();

        await Send.OkAsync(
            new()
            {
                MemberId = member.ID,
                MemberNumber = member.MemberNumber
            });
    }
}