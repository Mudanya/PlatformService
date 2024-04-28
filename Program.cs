using PlatformService.Data;
using PlatformService.Extensions;
using PlatformService.SyncData.Http;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//config svc
builder.Services.ConfigurePlatformRepo();
builder.Services.AddAutoMapper(typeof(Program)); // configure Automapper
builder.Services.AddHttpClient();
builder.Services.ConfigureCommandClient();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    builder.Services.ConfigureInMemoryContext();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    builder.Services.ConfigureSqlContext(builder.Configuration);
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
// seed data
PrepDb.PrepPopulation(app,app.Environment.IsProduction());
app.Run();
