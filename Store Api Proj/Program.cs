using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Store_Api_Proj.AutoMappers;
using Store_Api_Proj.Data;
using Store_Api_Proj.Interfaces;
using Store_Api_Proj.Repository;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IOrder, OrderRepository>();
//builder.Services.AddAutoMapper(typeof(IMapper));
void ConfigureServices(IServiceCollection services)
{
    // .... Ignore code before this

    // Auto Mapper Configurations
    var mappingConfig = new MapperConfiguration(mc =>
    {
        mc.AddProfile(new MappingProfiles());
    });

    IMapper mapper = mappingConfig.CreateMapper();
    services.AddSingleton(mapper);

    services.AddMvc();

}


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
