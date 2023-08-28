using FastEndpoints.Swagger;

var bld = WebApplication.CreateBuilder();
bld.Services
   .AddFastEndpoints()
   .SwaggerDocument();

var app = bld.Build();
app.UseAuthorization()
   .UseFastEndpoints()
   .UseSwaggerGen();
app.Run();

public partial class Program { }