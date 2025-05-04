﻿namespace StoreApiProject.Authentication.Interfaces;

public interface IAuthService
{
    Task<string> AuthenticateAsync(string username, string password);
}
