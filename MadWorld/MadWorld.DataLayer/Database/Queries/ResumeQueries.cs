using System;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries
{
    public class ResumeQueries : IResumeQueries
    {
        MadWorldContext _context;

        public ResumeQueries(MadWorldContext context)
        {
            _context = context;
        }

        public Resume GetLastResume()
        {
            return _context.Resumes.OrderBy(r => r.Created).LastOrDefault();
        }
    }
}
