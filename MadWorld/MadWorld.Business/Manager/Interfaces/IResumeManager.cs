using System;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.Business.Manager.Interfaces
{
    public interface IResumeManager
    {
        Resume GetLastResume();
    }
}
