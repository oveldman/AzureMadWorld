using MadWorld.Business.Manager;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Helper;
using MadWorld.Shared.Models.Pages;
using MadWorld.Tests.Setup;

namespace MadWorld.Tests.Business.Manager
{
    public class ResumeManagerTests
    {
        [Theory]
        [AutoDomainData]
        public void GetResume_NoParameters_ResumeFound(
            [Frozen] Mock<IResumeQueries> resumeQueries,
            ResumeManager resumeManager,
            Resume dbResume
            )
        {
            // Test data
            dbResume.Birthdate = new DateTime(2000, 10, 10);

            // Setup
            SystemTime.SetDateTime(new DateTime(2020, 09, 10));
            resumeQueries.Setup(rq => rq.GetLastResume()).Returns(dbResume);

            // Act
            ResumeResponse resumeResult = resumeManager.GetLastResume();

            // Assert
            Assert.Equal(19, resumeResult.Age);
            Assert.Equal(dbResume.Nationality ,resumeResult.Nationality);
            Assert.Equal(dbResume.FullName, resumeResult.FullName);

            // No Teardown
            SystemTime.ResetDateTime();
        }

        [Theory]
        [AutoDomainData]
        public void GetResume_NoParameters_ResumeNotFound(
            [Frozen] Mock<IResumeQueries> resumeQueries,
            ResumeManager resumeManager
            )
        {
            // No Test data

            // Setup
            resumeQueries.Setup(rq => rq.GetLastResume()).Returns<Resume>(null);

            // Act
            ResumeResponse resumeResult = resumeManager.GetLastResume();

            // Assert
            Assert.Equal(-1, resumeResult.Age);
            Assert.Null(resumeResult.FullName);
            Assert.Null(resumeResult.Nationality);

            // No Teardown
        }
    }
}
