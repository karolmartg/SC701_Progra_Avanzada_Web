using PAW.MinimalApi.Factory;
using PAW.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Nuevo
builder.Services.AddScoped<ICatalogFactory, CatalogFactory>();  

var app = builder.Build();


// Nuevo
using (var scope = app.Services.CreateScope())
{
    var factory = scope.ServiceProvider.GetService<ICatalogFactory>();
    var entity = factory.CreateEntity<PAW.Models.Entities.CatalogTask>();
    Console.WriteLine($"Entidad creada: {entity}");
}


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
