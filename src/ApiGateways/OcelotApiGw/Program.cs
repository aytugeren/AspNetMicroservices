using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Cache.CacheManager;

var builder = WebApplication.CreateBuilder(args);

builder.Logging.AddJsonConsole();
builder.Logging.AddDebug();
builder.Logging.AddConsole();
builder.Services.AddHttpClient<ICatalogService, CatalogService>(c => c.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:CatalogUrl")));
builder.Services.AddHttpClient<IBasketService, BasketService>(c => c.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:BasketUrl")));
builder.Services.AddHttpClient<IOrderService, OrderService>(c => c.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:OrderingUrl")));
builder.Services.AddOcelot().AddCacheManager(settings => settings.WithDictionaryHandle());

var app = builder.Build();

builder.Configuration.AddJsonFile($"ocelot.{app.Environment.EnvironmentName}.json", true, true);

app.MapGet("/", () => "Hello World!");
await app.UseOcelot();
app.Run();
