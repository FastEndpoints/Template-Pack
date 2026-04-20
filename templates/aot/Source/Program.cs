var bld = WebApplication.CreateSlimBuilder(args);
bld.Services
   .AddAuthenticationJwtBearer(s => s.SigningKey = bld.Configuration["Auth:JwtKey"])
   .AddAuthorization()
   .AddFastEndpoints(o => o.SourceGeneratorDiscoveredTypes = DiscoveredTypes.All)
   .OpenApiDocument(o => o.DocumentName = "v1");

var app = bld.Build();
app.MapGet("/healthy", () => Results.Ok()).ExcludeFromDescription();
app.MapScalarApiReference(o => o.AddDocument("v1"));
app.UseAuthentication()
   .UseAuthorization()
   .UseFastEndpoints(
       c =>
       {
           c.Serializer.Options.AddSerializerContextsFromMyApp();
           c.Binding.ReflectionCache.AddFromMyApp();
           c.Errors.UseProblemDetails();
       });

await app.ExportOpenApiDocsAndExitAsync("v1"); //export openapi json during aot publish

if (app.Environment.IsDevelopment())
    app.MapOpenApi(); //serve live openapi json during development
else
    app.UseStaticFiles(); //serve exported openapi json in production

app.Run();