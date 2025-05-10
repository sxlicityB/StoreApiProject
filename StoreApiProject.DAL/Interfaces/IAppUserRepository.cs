using StoreApiProject.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.DAL.Interfaces;

public interface IAppUserRepository
{
    Task<ICollection<AppUser>> GetUsersAsync();
    Task<AppUser> GetUserAsync(int id);
    Task<bool> CreateUserAsync(AppUser user);
    Task<bool> UpdateUserAsync();
    Task<bool> EditUserAsync(AppUser user);
    Task<bool> DeleteUserAsync(int id);
}
