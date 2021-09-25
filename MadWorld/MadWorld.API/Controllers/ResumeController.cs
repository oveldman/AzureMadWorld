using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Models.Pages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ResumeController : ControllerBase
    {
        private readonly ILogger<ResumeController> _logger;
        private readonly IResumeManager _resumeManager;

        public ResumeController(ILogger<ResumeController> logger, IResumeManager resumeManager)
        {
            _logger = logger;
            _resumeManager = resumeManager;
        }

        // GET: /<controller>/
        [HttpGet]
        public ResumeResponse Get()
        {
            Resume resume = _resumeManager.GetLastResume();

            return new ResumeResponse
            {
                FullName = resume.FullName
            };
        }
    }
}
