using usingMinimalAPI;
using usingMinimalAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton<IProductService, ProductService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("products", (IProductService productService) =>
{
    var products = productService.GetProducts();
    return Results.Ok(products);
});

app.MapGet("producs/{id:int}", (IProductService productService, int id) =>
{
    var product = productService.GetProduct(id);
    return Results.Ok(product);
});

app.MapGet("producs/search/{name}", (IProductService productService, string name) =>
{
    var products = productService.Search(name);
    return Results.Ok(products);
});

app.MapPost("products/createNew", (IProductService productService, CreateProductRequest request) =>
{
    var id = productService.CreateNewProduct(request);
    return Results.Created($"https://localhost:7194/producs/{id}", null);
});



app.Run();

