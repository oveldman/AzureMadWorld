using System;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Pages.Support;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface ISecurityReportManager
    {
        BaseResponse Save(SecurityReportRequest report);
    }
}
