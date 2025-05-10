using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.Domain.Models;

public class AppUser
{
    public int UserId { get; set; }
    public string Email { get; set; } = null!;
    public string? Username { get; set; }
    public string PasswordHash { get; set; } = null!;
    public string Role { get; set; } = "User";
    public Buyer? Buyer { get; set; }                   // navigational 
}
