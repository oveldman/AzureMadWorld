using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.Shared.Models.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers
{
    [ApiController]
    [Authorize]
    [Route("[controller]")]
    public class AuthorizeController : ControllerBase
    {
        private readonly IAuthorizationManager _authorizationManager;
        private readonly ILogger<AuthorizeController> _logger;

        public AuthorizeController(ILogger<AuthorizeController> logger, IAuthorizationManager authorizationManager)
        {
            _authorizationManager = authorizationManager;
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCurrentUserRols")]
        public RolesResponse GetCurrentUserRols()
        {
            var identity = User.Identity as ClaimsIdentity;
            string azureID = identity.Claims.FirstOrDefault(c => c.Type == "http://schemas.microsoft.com/identity/claims/objectidentifier")?.Value;

            return new RolesResponse
            {
                Roles = _authorizationManager.GetRoles(azureID)
            };
        }
    }
}

