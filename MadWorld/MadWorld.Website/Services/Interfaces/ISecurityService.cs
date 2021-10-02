using System;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Pages.Support;

namespace MadWorld.Website.Services.Interfaces
{
    public interface ISecurityService
    {
        Task<BaseResponse> SendReport(SecurityReportRequest request);
    }
}
