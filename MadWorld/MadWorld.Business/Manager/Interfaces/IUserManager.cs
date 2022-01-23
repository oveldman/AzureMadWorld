using System;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Admin;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface IUserManager
    {
        UsersResponse GetUsers();
        UserResponse GetUser(string id);
        BaseResponse UpdateUser(UserDTO user);
    }
}

