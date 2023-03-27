using ModularMonolith.Modules.Conferences.Api;
using ModularMonolith.Modules.Speakers.Api;
using ModularMonolith.Modules.Tickets.Api;
using ModularMonolith.Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddConferencesModule();
builder.Services.AddSpeakersModule();
builder.Services.AddTicketsModule();
builder.Services.AddInfrastructure();

var app = builder.Build();

app.UseInfrastructure();
app.UseRouting();
app.UseConferencesModule();
app.UseSpeakersModule();
app.UseTicketsModule();
app.MapControllers();
app.MapGet("/", () => "Modular Monolith API");

app.Run();
