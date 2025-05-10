using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreApiProject.Domain.Models;

internal class User
{
    public string Username { get; set; }
    public string Password { get; set; } // Normally hashed
    public string Role { get; set; }
}
