using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder(args);
bld.Services
   .AddAuthorization()
   .AddFastEndpoints()
   .SwaggerDocument();

var app = bld.Build();
app.UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();
app.Run();

public partial class Program { }