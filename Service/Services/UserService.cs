using System;
using Domain.Interfaces;

namespace Service.Services
{
    public class UserService : IUserService
    {

        public bool IsValidUser(string username, string password)
        {
            // Logic for user validation
            // Hard Code for demonstration
            if (username.Equals("admin") && password.Equals("admin"))
                return true;
            else
                return false;
        }
    }
}
