using System;
using System.Threading.Tasks;

namespace MadWorld.Website.State.Interface
{
    public interface IAuthenticationHandler
    {
        Task<bool> ResetRoles();
    }
}

