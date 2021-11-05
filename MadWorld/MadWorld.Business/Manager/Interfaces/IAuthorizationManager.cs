using System;
using MadWorld.DataLayer.Database.Enum;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface IAuthorizationManager
    {
        List<string> GetRoles(string azureID);
        bool IsAuthorizated(string azureID, Roles role, string email);
    }
}

