using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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
        private readonly ILogger<AuthorizeController> _logger;

        public AuthorizeController(ILogger<AuthorizeController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        [Route("GetCurrentUserRols")]
        public RolesResponse GetCurrentUserRols()
        {
            return new RolesResponse
            {
                Roles = new List<string>
                {
                    "Adminstrator"
                }
            };
        }
    }
}

