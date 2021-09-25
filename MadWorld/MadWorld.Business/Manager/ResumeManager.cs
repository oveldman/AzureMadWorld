using System;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.Business.Manager
{
    public class ResumeManager : IResumeManager
    {
        IResumeQueries _resumeQueries;

        public ResumeManager(IResumeQueries resumeQueries)
        {
            _resumeQueries = resumeQueries;
        }

        public Resume GetLastResume()
        {
            return _resumeQueries.GetLastResume();
        }
    }
}
