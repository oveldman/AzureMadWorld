using System;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Web.Models.Pages;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface IResumeManager
    {
        ResumeResponse GetLastResume();
    }
}
