using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Logging.AddJsonConsole();
builder.Logging.AddDebug();
builder.Logging.AddConsole();
builder.Services.AddOcelot();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");

await app.UseOcelot();

app.Run();
