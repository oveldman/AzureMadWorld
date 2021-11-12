using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MadWorld.API.Attribute;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Enum;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Pages.Support;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MadWorld.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SupportController : ControllerBase
    {
        private readonly ILogger<SupportController> _logger;
        private readonly ISecurityReportManager _securityReportManager;

        public SupportController(ILogger<SupportController> logger, ISecurityReportManager securityReportManager)
        {
            _logger = logger;
            _securityReportManager = securityReportManager;
        }

        [HttpGet]
        [Route("CreateAccount")]
        [AuthorizeMW(Roles.None)]
        public BaseResponse CreateAccount()
        {
            return new BaseResponse();
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

            return new BaseResponse
            {
                Error = true,
                ErrorMessage = "Model is not valid"
            };
        }

        private bool IsValid<T>(T request)
        {
            return TryValidateModel(request, nameof(T));
        }
    }
}
