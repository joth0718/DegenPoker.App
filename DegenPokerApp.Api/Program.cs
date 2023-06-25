using DegenPokerApp.Api.Data;
using DegenPokerApp.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .AddJsonFile("appsettings.Development.json")
    .Build();



builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();
builder.Services.AddHttpClient();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DegenPokerContext>(optionsbuilder =>
optionsbuilder.UseCosmos(
    connectionString: config["CosmosDB:URL"],
    databaseName: config["DatabaseName"],
    cosmosOptionsAction: options =>
    {
        options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
        options.MaxRequestsPerTcpConnection(20);
        options.MaxTcpConnectionsPerEndpoint(32);
    }));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped<IPokerClubRepository, PokerClubRepository>();
builder.Services.AddScoped<IPokerSessionRepository, PokerSessionRepository>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.UseCors("Open");

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
