using Microsoft.OpenApi.Models;
using Microsoft.EntityFrameworkCore;
using PizzaApi.Persistence;
using PizzaApi.Core.Models;
using PirzzaApi.Core;

var builder = WebApplication.CreateBuilder(args);


var connectionString = 
        builder
        .Configuration
        .GetConnectionString(Constants.DATABASE_CONFIGURATION_KEY) ?? Constants.CONNECTION_STRING_NAME;

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSqlite<PizzaContextDb>(connectionString);
builder.Services.AddSwaggerGen(c =>
{
     c.SwaggerDoc(AppInfo.Version[0], new OpenApiInfo {
         Title = AppInfo.Title,
         Description = AppInfo.Description,
         Version = AppInfo.Version[0] });
});


var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint(Constants.SWAGGER_JSON_PATH, Constants.SEAGGER_API_DESCRIPTION);
});


app.MapGet(Constants.PIZZAS_FIND_ALL_PATH, async (PizzaContextDb db) => await db.Pizzas.ToListAsync());
app.MapGet(Constants.PIZZAS_FIND_BY_ID, async (PizzaContextDb db, int id) => await db.Pizzas.FindAsync(id));
app.MapPost(Constants.PIZZAS_CREATE_PATH, async (PizzaContextDb db, Pizza pizza) =>
{
    await db.Pizzas.AddAsync(pizza);
    await db.SaveChangesAsync();
    return Results.Created($"{Constants.PIZZAS_CREATE_PATH}/{pizza.Id}", pizza);
});
app.MapPut(Constants.PIZZAS_UPDATE_PATH, async (PizzaContextDb db, Pizza updatepizza, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza == null) return Results.NotFound();
    pizza.Name = updatepizza.Name;
    pizza.Description = updatepizza.Description;
    await db.SaveChangesAsync();
    return Results.NoContent();

});
app.MapDelete(Constants.PIZZAS_DELETE_PATH, async (PizzaContextDb db, int id) =>
{
    var pizza = await db.Pizzas.FindAsync(id);
    if (pizza is null)
    {
        return Results.NotFound();
    }

    db.Pizzas.Remove(pizza);
    await db.SaveChangesAsync();
    return Results.Ok();
});


app.Run();
