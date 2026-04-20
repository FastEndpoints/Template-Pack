using Amazon;
using Amazon.SimpleEmailV2;
using Dom;
using LettuceEncrypt;
using MongoDB.Driver;
using Xunit.Runner.InProc.SystemConsole;

if (args.Contains("@@")) // this is a 'dotnet test' run
    return await ConsoleRunner.Run(args);

var bld = WebApplication.CreateBuilder(args);
bld.Services
   .AddAuthenticationJwtBearer(o => o.SigningKey = bld.Configuration["Auth:SigningKey"])
   .AddAuthorization()
   .AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All)
   .AddJobQueues<JobRecord, JobStorageProvider>()
   .AddSingleton<IAmazonSimpleEmailServiceV2>(
       new AmazonSimpleEmailServiceV2Client(
           bld.Configuration["Email:ApiKey"],
           bld.Configuration["Email:ApiSecret"],
           RegionEndpoint.USEast1));

if (bld.Environment.IsProduction())
{
    bld.Services
       .AddLettuceEncrypt()
       .PersistDataToDirectory(new("/home/MyProject/certs"), null);
}
else
{
    bld.Services.OpenApiDocument(
        o =>
        {
            o.DocumentName = "v0";
            o.Version = "0.0.0";
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
    app.MapOpenApi();

app.Run();

return 0;

async Task InitDatabase(string? dbName)
{
    ArgumentNullException.ThrowIfNull(dbName);
    await DB.InitAsync(dbName); //await DB.InitAsync(dbName, MongoClientSettings.FromConnectionString("mongodb://admin:password@localhost:27017/?authSource=admin"));
    await DB.MigrateAsync();
    await Notification.Initialize();
}