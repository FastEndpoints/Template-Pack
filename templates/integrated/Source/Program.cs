using Amazon;
using Amazon.SimpleEmailV2;
using Dom;
using LettuceEncrypt;

var bld = WebApplication.CreateBuilder(args);
bld.Services
   .AddAuthenticationJwtBearer(o => o.SigningKey = bld.Configuration["Auth:SigningKey"])
   .AddAuthorization()
   .AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All)
   .AddJobQueues<JobRecord, JobStorageProvider>()
   .AddSingleton<IAmazonSimpleEmailServiceV2>(
       new AmazonSimpleEmailServiceV2Client(
           awsAccessKeyId: bld.Configuration["Email:ApiKey"],
           awsSecretAccessKey: bld.Configuration["Email:ApiSecret"],
           region: RegionEndpoint.USEast1));

if (bld.Environment.IsProduction())
{
    bld.Services
       .AddLettuceEncrypt()
       .PersistDataToDirectory(new("/home/MyProject/certs"), null);
}
else
{
    bld.Services.SwaggerDocument(
        d => d.DocumentSettings =
                 s =>
                 {
                     s.DocumentName = "v0";
                     s.Version = "0.0.0";
                 });
}

var app = bld.Build();

app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints(
       c =>
       {
           c.Binding.ReflectionCache.AddFromMyProject();
           c.Errors.UseProblemDetails();
       });

await InitDatabase(app.Configuration["Database:Name"]);

app.UseJobQueues(
    o =>
    {
        o.MaxConcurrency = 4;
        o.ExecutionTimeLimit = TimeSpan.FromSeconds(20);
    });

if (!app.Environment.IsProduction())
    app.UseSwaggerGen(uiConfig: u => u.DeActivateTryItOut());

app.Run();

async Task InitDatabase(string? dbName)
{
    ArgumentNullException.ThrowIfNull(dbName);
    await DB.InitAsync(dbName);
    await DB.MigrateAsync();
    await Notification.Initialize();
}

public partial class Program;