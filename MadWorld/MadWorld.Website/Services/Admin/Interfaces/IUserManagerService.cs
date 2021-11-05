using System;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin;

namespace MadWorld.Website.Services.Admin.Interfaces
{
    public interface IUserManagerService
    {
        Task<UsersResponse> GetUsers();
        Task<UserResponse> GetUser(string id);
        Task<BaseResponse> SaveUser(UserDTO user);
    }
}

