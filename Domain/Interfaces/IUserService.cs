using System;
namespace Domain.Interfaces
{
    public interface IUserService
    {
        bool IsValidUser(string username, string password);
    }
}
