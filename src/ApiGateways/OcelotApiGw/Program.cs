using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddJsonConsole();
builder.Logging.AddDebug();
builder.Logging.AddConsole();
builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

builder.Configuration.AddJsonFile($"ocelot.{app.Environment.EnvironmentName}.json", true, true);

app.MapGet("/", () => "Hello World!");
await app.UseOcelot();
app.Run();
