using AutoMapper.Data;
using AutoShopMongo.API.AutoMapper;
using AutoShopMongo.Domain.UseCases.Gateway;
using AutoShopMongo.Domain.UseCases.Gateway.Repositories;
using AutoShopMongo.Domain.UseCases.UseCases;
using AutoShopMongo.Infrastructure;
using AutoShopMongo.Infrastructure.Interfaces;
using AutoShopMongo.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(config => config.AddDataReaderMapping(), typeof(Configuration));

builder.Services.AddScoped<IShopUseCase, ShopUseCase>();
builder.Services.AddScoped<IShopRepository, ShopRepository>();

builder.Services.AddSingleton<IContext>(provider => new Context(builder.Configuration.GetConnectionString("urlConnection"), "Shops"));

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
