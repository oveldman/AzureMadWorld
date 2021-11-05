using System;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface IUserManager
    {
        UsersResponse GetUsers();
        UserResponse GetUser(string id);
        BaseResponse UpdateUser(UserDTO user);
    }
}

