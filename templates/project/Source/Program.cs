var bld = WebApplication.CreateBuilder(args);
bld.Services
   .AddAuthenticationJwtBearer(s => s.SigningKey = bld.Configuration["Auth:JwtKey"])
   .AddAuthorization()
   .AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes.AddRange(DiscoveredTypes.All))
   .SwaggerDocument();

var app = bld.Build();
app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints(c => c.Errors.UseProblemDetails())
   .UseSwaggerGen();
app.Run();

public partial class Program { }