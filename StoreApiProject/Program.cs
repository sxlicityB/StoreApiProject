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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using StoreApiProject.Authentication;
using System.Text;
using StoreApiProject.Authentication.Services;
using StoreApiProject.Authentication.Interfaces;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration                                                                                               //Load development profile if in dev environment
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables(); //override both files if set



var jwtSettings = builder.Configuration.GetSection("JwtSettings").Get<JwtSettings>();       

builder.Services.AddAuthentication("Bearer")                                                //register and configure JWT auth
    .AddJwtBearer("Bearer", options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = jwtSettings.Issuer,
            ValidAudience = jwtSettings.Audience,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.SecretKey))
        };
    });

builder.Services.AddAuthorization();





// Add services to the project.

builder.Services.AddControllers();
builder.Services.AddBLLServices();                       // DAL repos registration is referenced in BLL
builder.Services.AddAutoMapper(typeof(MappingProfiles));

//JWT
builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
builder.Services.AddScoped<JwtService>();                // JWT auth DI
builder.Services.AddScoped<IAuthService, AuthService>(); // auth service DI






builder.Services.AddFluentValidationAutoValidation();                        // Validtion injection
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

app.UseRouting();

app.UseAuthentication();  // enable JWT reading 
app.UseAuthorization();   // enable access control

app.MapControllers();

app.Run();
