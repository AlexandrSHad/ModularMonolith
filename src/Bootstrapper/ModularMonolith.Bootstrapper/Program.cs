using ModularMonolith.Modules.Conferences.Api;
using ModularMonolith.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddConferencesModule();

var app = builder.Build();

app.UseInfrastructure();
app.UseRouting();
app.UseConferencesModule();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
