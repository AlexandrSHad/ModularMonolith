using ModularMonolith.Modules.Conferences.Api;
using ModularMonolith.Modules.Speakers.Api;
using ModularMonolith.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddInfrastructure();
builder.Services.AddControllers();
builder.Services.AddConferencesModule();
builder.Services.AddSpeakersModule();

var app = builder.Build();

app.UseInfrastructure();
app.UseRouting();
app.UseConferencesModule();
app.UseSpeakersModule();
app.MapControllers();
app.MapGet("/", () => "Hello World!");

app.Run();
