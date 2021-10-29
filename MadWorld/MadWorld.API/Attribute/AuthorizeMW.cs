using System;
using System.Linq;
using System.Security.Claims;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Enum;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.DependencyInjection;

namespace MadWorld.API.Attribute
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public class AuthorizeMW : AuthorizeAttribute, IAuthorizationFilter
    {
        private readonly Roles Role;

        public AuthorizeMW(Roles role)
        {
            Role = role;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            ClaimsIdentity identity = context.HttpContext.User.Identity as ClaimsIdentity;
            if (!identity.IsAuthenticated)
            {
                // it isn't needed to set unauthorized result 
                // as the base class already requires the user to be authenticated
                // this also makes redirect to a login page work properly
                // context.Result = new UnauthorizedResult();
                return;
            }

            // you can also use registered services
            var authorizationManager = context.HttpContext.RequestServices.GetService<IAuthorizationManager>();
            string azureID = identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;
            string email = identity.Claims.FirstOrDefault(c => c.Type == "emails")?.Value;
            var isAuthorized = authorizationManager.IsAuthorizated(azureID, Role, email);
            if (!isAuthorized)
            {
                context.Result = new StatusCodeResult((int)System.Net.HttpStatusCode.Forbidden);
                return;
            }
        }
    }
}

