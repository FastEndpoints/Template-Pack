using MyProject;

namespace Members.Signup;

sealed class DuplicateInfoChecker : IPreProcessor<Request>
{
    public async Task PreProcessAsync(IPreProcessorContext<Request> ctx, CancellationToken c)
    {
        var tEmail = DB.Find<Dom.Member>()
                       .Match(m => m.Email == ctx.Request.Email.LowerCase())
                       .ExecuteAnyAsync(cancellation: c);

        var tMobile = DB.Find<Dom.Member>()
                        .Match(m => m.MobileNumber == ctx.Request.Contact.MobileNumber.Trim())
                        .ExecuteAnyAsync(cancellation: c);

        var (eml, mob) = await Tasks.Run(tEmail, tMobile);

        if (eml)
            ctx.ValidationFailures.Add(new(nameof(Request.Email), "Email address is in use!"));
        if (mob)
            ctx.ValidationFailures.Add(new($"{nameof(Request.Contact)}.{nameof(Request.Contact.MobileNumber)}", "Mobile number is in use!"));

        if (ctx.ValidationFailures.Count > 0)
            await ctx.HttpContext.Response.SendErrorsAsync(ctx.ValidationFailures, cancellation: c);
    }
}