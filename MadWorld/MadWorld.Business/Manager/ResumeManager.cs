using System;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Web.Helper;
using MadWorld.Shared.Web.Models.Pages;

namespace MadWorld.Business.Manager
{
    public class ResumeManager : IResumeManager
    {
        // -1 means birthday is not valid.
        private const int NoAgeFound = -1;

        IResumeQueries _resumeQueries;

        public ResumeManager(IResumeQueries resumeQueries)
        {
            _resumeQueries = Guard.Against.Null(resumeQueries);
        }

        public ResumeResponse GetLastResume()
        {
            IOption<Resume> resumeOption = _resumeQueries.GetLastResume();

            if (resumeOption.HasValue)
            {
                Resume resume = resumeOption.GetValue();

                return new ResumeResponse
                {
                    Age = GetAge(resume?.Birthdate),
                    FullName = resume?.FullName,
                    Nationality = resume?.Nationality
                };
            }

            return new ResumeResponse()
            {
                Age = NoAgeFound
            };
        }

        private int GetAge(DateTime? birthdate)
        {
            if (!birthdate.HasValue)
            {
                return NoAgeFound;
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
