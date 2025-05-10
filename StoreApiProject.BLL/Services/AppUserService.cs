using StoreApiProject.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StoreApiProject.BLL.Interfaces;
using StoreApiProject.Domain.Models;

namespace StoreApiProject.BLL.Services;

public class AppUserService : IAppUserService
{
    private readonly IAppUserRepository _appUserRepository;
    public AppUserService(IAppUserRepository userRepository)
    {
        userRepository = _appUserRepository;
    }
    public async Task<ICollection<AppUser>> GetUsersAsync()
    {
        return await _appUserRepository.GetUsersAsync();
    }
    public async Task<AppUser> GetUserAsync(int id)
    {
        return await _appUserRepository.GetUserAsync(id);
    }
    public async Task<bool> CreateUserAsync(AppUser user)
    {
        return await _appUserRepository.CreateUserAsync(user);
    }
    public async Task<bool> UpdateUserAsync()
    {
        return await _appUserRepository.UpdateUserAsync();
    }
    public async Task<bool> EditUserAsync(AppUser user)
    {
        return await _appUserRepository.EditUserAsync(user);
    }
    public async Task<bool> DeleteUserAsync(int id)
    {
        return await _appUserRepository.DeleteUserAsync(id);
    }
}
