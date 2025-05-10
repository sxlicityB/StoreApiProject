using Microsoft.Extensions.DependencyInjection;
using StoreApiProject.BLL.Interfaces;
using StoreApiProject.BLL.Services;
using StoreApiProject.DAL.Interfaces;
using StoreApiProject.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.BLL
{
    public static class BLLServiceRegistration
    {
        public static void AddBLLServices(this IServiceCollection services)
        {
            services.AddScoped<IBuyerService, BuyerService>();
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IDataService, DataService>();
            services.AddScoped<IAppUserService, AppUserService>();

            services.AddDALServces();
        }
    }
}
