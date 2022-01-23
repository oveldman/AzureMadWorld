using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.API.Attribute;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Enum;
using MadWorld.Shared.Web.Creators;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Pages.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("[controller]")]
    public class SupportController : ControllerBase
    {
        private readonly ILogger<SupportController> _logger;
        private readonly ISecurityReportManager _securityReportManager;

        public SupportController(ILogger<SupportController> logger, ISecurityReportManager securityReportManager)
        {
            _logger = logger;
            _securityReportManager = Guard.Against.Null(securityReportManager, nameof(securityReportManager));
        }

        [HttpPost]
        [Route("ReportSecurity")]
        public BaseResponse ReportSecurity(SecurityReportRequest request)
        {
            var ipAddress = HttpContext.Connection.RemoteIpAddress?.ToString();

            if (IsValid(request) && !string.IsNullOrEmpty(ipAddress))
            {
                return _securityReportManager.Save(request, ipAddress);
            }

            return ResponseCreators.CreateErrorResponse<BaseResponse>("Model is not valid");
        }

        private bool IsValid<T>(T request)
        {
            return TryValidateModel(request, nameof(T));
        }
    }
}
