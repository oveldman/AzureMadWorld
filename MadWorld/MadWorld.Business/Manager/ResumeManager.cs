using System;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Helper;
using MadWorld.Shared.Models.Pages;

namespace MadWorld.Business.Manager
{
    public class ResumeManager : IResumeManager
    {
        IResumeQueries _resumeQueries;

        public ResumeManager(IResumeQueries resumeQueries)
        {
            _resumeQueries = resumeQueries;
        }

        public ResumeResponse GetLastResume()
        {
            Resume resume = _resumeQueries.GetLastResume();

            return new ResumeResponse
            {
                Age = GetAge(resume.Birthdate),
                FullName = resume.FullName,
                Nationality = resume.Nationality
            };
        }

        private int GetAge(DateTime? birthdate)
        {
            // -1 means birthday is not valid.
            if (!birthdate.HasValue)
            {
                return -1;
            }

            // Save today's date.
            var today = SystemTime.Now();

            // Calculate the age.
            var age = today.Year - birthdate.Value.Year;

            // Go back to the year in which the person was born in case of a leap year
            if (birthdate.Value.Date > today.AddYears(-age)) age--;

            return age;
        }
    }
}
