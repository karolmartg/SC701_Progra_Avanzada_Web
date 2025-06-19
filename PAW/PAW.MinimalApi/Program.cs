using Microsoft.EntityFrameworkCore;
using PAW.Business;
using PAW.MinimalApi.Factory;
using PAW.Models;

using PAW.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Esto es otra forma de hacerlo con Factory:
builder.Services.AddScoped<ICatalogFactory, CatalogFactory>();

builder.Services.AddScoped<IBusinessCatalog, BusinessCatalog>();
builder.Services.AddScoped<IRepositoryCatalog, RepositoryCatalog>();


// Connection with API
builder.Services.AddDbContext<CatalogDbContext>(opt => opt.UseSqlServer(builder.Configuration.GetConnectionString("CatalogConnection")));

var app = builder.Build();

// Forma sin Factory

app.MapGet("/catalog", async (IBusinessCatalog business) =>
{
    return await business.GetAllCatalogsAsync();
});


// Otra forma de hacerlo con Factory:
/*
app.MapGet("/catalog", async (ICatalogFactory factory, IBusinessCatalog business) =>
{
    var catalog = factory.CreateEntity<Catalog>() as Catalog;
    await business.GetAllCatalogsAsync();
});

app.MapPut("/catalog", async (Catalog? catalog, ICatalogFactory factory, IBusinessCatalog business) =>
{
    catalog ??= factory.CreateEntity<Catalog>() as Catalog;

    factory.ApplyAuditing(catalog, string.Empty, isInserting: false);
    await business.SaveCatalogAsync(catalog);
});
*/

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
