using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using StoreApiProject.DAL.Data;
using StoreApiProject.DAL.Interfaces;
using StoreApiProject.DAL.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.DAL;

public static class DALServiceRegistration
{
    public static void AddDALServces(this IServiceCollection services) 
    {
        services.AddScoped<IBuyerRepository, BuyerRepository>();
        services.AddScoped<IDataRepository, DataRepository>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IProductRepository, ProductRepository>();
        services.AddScoped<IAppUserRepository, AppUserRepository>();
    }
}
