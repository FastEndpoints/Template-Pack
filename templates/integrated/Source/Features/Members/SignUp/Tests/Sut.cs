using Amazon.SimpleEmailV2;
using Dom;

namespace Members.Signup.Tests;

public class Sut : AppFixture<Program>
{
    internal Request SignupRequest { get; set; } = default!;
    internal string? MemberId { get; set; }

    protected override void ConfigureApp(IWebHostBuilder a)
    {
        a.UseContentRoot(Directory.GetCurrentDirectory());
    }

    protected override void ConfigureServices(IServiceCollection s)
    {
        s.AddSingleton<IAmazonSimpleEmailServiceV2, SesClient>();
    }

    protected override ValueTask SetupAsync()
    {
        SignupRequest = new()
        {
            UserDetails = new()
            {
                FirstName = Fake.Name.FirstName(),
                LastName = Fake.Name.LastName()
            },
            Address = new()
            {
                City = Fake.Address.City(),
                State = Fake.Address.State(),
                ZipCode = Fake.Address.ZipCode("#####"),
                Street = Fake.Address.StreetAddress()
            },
            BirthDay = "1983-10-10",
            Contact = new()
            {
                MobileNumber = Fake.Phone.PhoneNumber("##########"),
                Telegram = true,
                Whatsapp = true
            },
            Email = Fake.Internet.Email(),
            Gender = "Male"
        };

        return ValueTask.CompletedTask;
    }

    protected override async ValueTask TearDownAsync()
    {
        await DB.DeleteAsync<Member>(MemberId);
        await DB.DeleteAsync<JobRecord>(j => j.IsComplete == true);
    }
}