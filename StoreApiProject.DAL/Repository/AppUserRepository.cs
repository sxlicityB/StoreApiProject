using Microsoft.EntityFrameworkCore;
using StoreApiProject.DAL.Data;
using StoreApiProject.DAL.Interfaces;
using StoreApiProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.DAL.Repository;

public class AppUserRepository : IAppUserRepository
{
    private readonly AppDbContext _context;
    public AppUserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ICollection<AppUser>> GetUsersAsync()
    {
        return await _context.AppUsers.OrderBy(x => x.UserId).ToListAsync();
    }
    public async Task<AppUser> GetUserAsync(int id)
    {
        return await _context.AppUsers.FindAsync(id);
    }
    public async Task<bool> CreateUserAsync(AppUser user)
    {
        _context.Add(user);
        return await UpdateUserAsync();
    }

    public async Task<bool> UpdateUserAsync()
    {
        var userUpdate = _context.SaveChanges();
        return userUpdate > 0;
    }
    public async Task<bool> EditUserAsync(AppUser user)
    {
        _context.Update(user);
        return await UpdateUserAsync();
    }
    public async Task<bool> DeleteUserAsync(int id)
    {
        var product = _context.Products.FirstOrDefault(o => o.ProductId == id);
        _context.Remove(product);
        return await UpdateUserAsync();
    }
}