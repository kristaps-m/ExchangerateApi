using Exchangerate.Integration;
using Refit;

var builder = WebApplication.CreateBuilder(args);
builder.Configuration.AddJsonFile("ExchangeAppSettings.json", optional: false);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var apiSettings = builder.Configuration.GetSection("ApiSettings");
var apiKey = apiSettings.GetValue<string>("ExchangeRatesApiKey");
builder.Services.AddRefitClient<IGetExchangerates>()
        .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://v6.exchangerate-api.com/"))
        .ConfigureHttpClient(c => c.DefaultRequestHeaders.Add("Accept", "application/json"))
        .ConfigureHttpClient(c => c.DefaultRequestHeaders.Add("User-Agent", "ExchangerateApi"))
        .ConfigureHttpClient(c => c.DefaultRequestHeaders.Add("apikey", apiKey));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors(options =>
{
    options.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
});

app.UseAuthorization();

app.MapControllers();

app.Run();
