using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Mini_e_handels_API.Data.Repositories;
using Mini_e_handels_API.Data.Repositories.IRepositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
// Register the InMemoryProductRepository as a singleton service
// This ensures that the same instance is used throughout the application lifecycle
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

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
