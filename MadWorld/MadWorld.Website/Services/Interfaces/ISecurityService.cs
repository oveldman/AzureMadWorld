using System;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Pages.Support;

namespace MadWorld.Website.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<BaseResponse> SendReport(SecurityReportRequest request);
    }
}
