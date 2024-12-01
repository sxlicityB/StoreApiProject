using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.AutoMappers;
using Store_Api_Proj.Data;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Repository;
using Store_Api_Proj.Validators;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the project.
builder.Services.AddControllers();
builder.Services.AddScoped<IOrder, OrderRepository>();
builder.Services.AddScoped<IBuyer, BuyerRepository>();
builder.Services.AddScoped<IProduct, ProductRepository>();
builder.Services.AddScoped<IDataService, DataRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddFluentValidationAutoValidation();           //Autovalidtion injection
builder.Services.AddValidatorsFromAssembly(typeof(CreateBuyerDTOValidator).Assembly);


//DB context injection
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
