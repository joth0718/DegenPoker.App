using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();

var cosmosConnectionString = config["CosmosConnectionString"];



builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddDbContextFactory<DegenPokerApp.Api.Data.DegenPokerContext>(optionsBuilder =>

optionsBuilder.UseCosmos(
    connectionString: cosmosConnectionString,
    databaseName: "DegenPokerAppDb",
    cosmosOptionsAction: options =>
    {
        options.ConnectionMode(Microsoft.Azure.Cosmos.ConnectionMode.Direct);
        options.MaxRequestsPerTcpConnection(20);
        options.MaxTcpConnectionsPerEndpoint(32);
    }));

builder.Services.AddTransient<DegenPokerApp.Api.Service.DegenPokerAppService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("Open", builder => builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
