using Shopping.Aggregator.Services;

var builder = WebApplication.CreateBuilder(args);
ConfigurationManager configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient<ICatalogService, CatalogService>(c => c.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:CatalogUrl")));
builder.Services.AddHttpClient<IBasketService, BasketService>(c => c.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:BasketUrl")));
builder.Services.AddHttpClient<IOrderService, OrderService>(c => c.BaseAddress = new Uri(configuration.GetValue<string>("ApiSettings:OrderingUrl")));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();
