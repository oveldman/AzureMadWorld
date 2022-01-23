using System;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Admin;

namespace MadWorld.Website.Services.Admin.Interfaces
{
    public interface IUserManagerService
    {
        Task<UsersResponse> GetUsers();
        Task<UserResponse> GetUser(string id);
        Task<BaseResponse> SaveUser(UserDTO user);
    }
}

