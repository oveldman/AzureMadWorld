using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MadWorld.Website.Services.Interfaces
{
    public interface IAccountService
    {
        Task<List<string>> GetCurrentAccountRoles();
    }
}

