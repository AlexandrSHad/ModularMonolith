using ModularMonolith.Modules.Conferences.Api;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddConferencesModule();

var app = builder.Build();

if (builder.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseRouting();

app.UseConferencesModule();

app.MapControllers();

app.MapGet("/", () => "Hello World!");

app.Run();
