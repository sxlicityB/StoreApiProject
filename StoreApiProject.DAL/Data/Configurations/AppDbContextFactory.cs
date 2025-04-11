using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.DAL.Data.Configurations;      // hard coding connection string since its just a learning project, would do a configuration layer otherwise

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();


        optionsBuilder.UseSqlServer("Data Source = DESKTOP-O0BC4KN\\SQLEXPRESS; Initial Catalog = StoreApi; User ID = StoreApiDeveloper; Password = vfhbyf1973; Connect Timeout = 30; Encrypt = True; TrustServerCertificate = True;");

        return new AppDbContext(optionsBuilder.Options);
    }
}