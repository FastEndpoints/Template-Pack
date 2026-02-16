var bld = WebApplication.CreateBuilder(args);
bld.Services
   .AddAuthenticationJwtBearer(s => s.SigningKey = bld.Configuration["Auth:JwtKey"])
   .AddAuthorization()
   .AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All)
   .SwaggerDocument();

var app = bld.Build();
app.UseStaticFiles()
   .UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints(
       c =>
       {
           c.Serializer.Options.AddSerializerContextsFromMyApp();
           c.Binding.ReflectionCache.AddFromMyApp();
           c.Errors.UseProblemDetails();
       });

await app.ExportSwaggerDocsAndExitAsync("v1");

app.UseOpenApi(c => c.Path = "/openapi/{documentName}.json");
app.MapScalarApiReference(o => o.AddDocument("v1"));

app.Run();