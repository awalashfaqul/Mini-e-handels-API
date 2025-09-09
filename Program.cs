using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Mini_e_handels_API.Data.Repositories;
using Mini_e_handels_API.Data.Repositories.IRepositories;
using Mini_e_handels_API.Services;
using Mini_e_handels_API.Services.IServices;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddControllers();
// Register the InMemoryProductRepository as a singleton service
// This ensures that the same instance is used throughout the application lifecycle
builder.Services.AddSingleton<IProductRepository, InMemoryProductRepository>(); // Stage 1 : a small API in .NET Core that manages a product catalog
builder.Services.AddSingleton<ICategoryRepository, InMemoryCategoryRepository>(); // Stage 2: Extend the API to manage products & categories
builder.Services.AddSingleton<ICartRepository, InMemoryCartRepository>(); // Stage 3: Extend the API to manage shopping carts
builder.Services.AddSingleton<IOrderRepository, OrderRepository>(); // Stage 3: Extend the API to manage orders
builder.Services.AddSingleton<IExperimentRepository, InMemoryExperimentRepository>(); // Stage 4: Extend the API to support experimentation
builder.Services.AddSingleton<IPersonalizationRepository, InMemoryPersonalizationRepository>(); // Stage 4: Extend the API to support personalization and experimentation
builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>(); // Stage 5: Extend the API to manage customers and their profiles
builder.Services.AddSingleton<INotificationService, InMemoryNotificationService>();
//builder.Services.AddSingleton<ICustomerRepository, InMemoryCustomerRepository>(); // new repo
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowFrontend",
        policy => policy.WithOrigins("http://localhost:5173") // vite default port
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowFrontend");

app.UseHttpsRedirection();
//app.UseAuthorization();

app.MapControllers();

app.Run();
