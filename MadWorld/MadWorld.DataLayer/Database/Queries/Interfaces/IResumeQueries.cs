using System;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries.Interfaces
{
    public interface IResumeQueries
    {
        IOption<Resume> GetLastResume();
    }
}
