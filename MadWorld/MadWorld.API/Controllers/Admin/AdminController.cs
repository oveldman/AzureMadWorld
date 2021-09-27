using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.Shared.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers.Admin
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public WelcomeResponse Index()
        {
            return new WelcomeResponse
            {
                Message = "Welcome back."
            };
        }
    }
}
