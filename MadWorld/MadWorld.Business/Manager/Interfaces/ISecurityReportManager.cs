using System;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Pages.Support;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface ISecurityReportManager
    {
        BaseResponse Save(SecurityReportRequest report, string ipAddress);
    }
}
