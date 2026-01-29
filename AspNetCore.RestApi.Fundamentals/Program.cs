using AspNetCore.RestApi.Fundamentals.Repositories;
using AspNetCore.RestApi.Fundamentals.Services;

var builder = WebApplication.CreateBuilder(args);

// Controllers (HTTP layer)
builder.Services.AddControllers();

// Dependency Injection (data + business logic)
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

// Swagger / OpenAPI
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Middleware pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.Run();