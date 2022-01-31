using System;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries
{
    public class ResumeQueries : IResumeQueries
    {
        private MadWorldContext _context;

        public ResumeQueries(MadWorldContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public IOption<Resume> GetLastResume()
        {
            Resume? resume = _context.Resumes.OrderBy(r => r.Created).LastOrDefault();
            return resume != null ? Option<Resume>.CreateSome(resume) : Option<Resume>.CreateNone();
        }
    }
}
