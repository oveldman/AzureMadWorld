using System;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Models.Pages;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface IResumeManager
    {
        ResumeResponse GetLastResume();
    }
}
