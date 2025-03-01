using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.Mapster;
using StoreApiProject.Validators;
using StoreApiProject.BLL;
using StoreApiProject.DAL;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using FluentValidation;
using FluentValidation.AspNetCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the project.
builder.Services.AddControllers();
builder.Services.AddBLLServices();                          // DAL repos registration is referenced in BLL
builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddFluentValidationAutoValidation();           // Validtion injection
builder.Services.AddValidatorsFromAssembly(typeof(CreateBuyerDTOValidator).Assembly);


//DB context injection from DAL
builder.Services.AddDbContext(builder.Configuration.GetConnectionString("DefaultConnection"));

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
