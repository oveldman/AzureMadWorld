using System;
using MadWorld.Business.Manager;
using MadWorld.DataLayer;
using MadWorld.DataLayer.Database.Enum;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.Tests.Business.Manager
{
	public class AuthorizationManagerTests
	{
        [Theory]
        [AutoDomainData]
        public void GetRoles_AzureID_AdminstratorFound(
            [Frozen] Mock<IAuthorizationQueries> authorizationQueries,
            AuthorizationManager authorizationManager,
            Account account,
            Guid azureID
            )
        {
            // Test data
            account.AzureID = azureID;
            account.IsAdminstrator = true;

            // Setup
            authorizationQueries.Setup(aq => aq.GetAccount(It.IsAny<Guid>())).Returns(account);

            // Act
            List<string> roles = authorizationManager.GetRoles(azureID.ToString());

            // Assert
            Assert.True(roles.Count == 1, "Expected a list of 1 role");
            Assert.Equal("Adminstrator", roles[0]);

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void GetRoles_AzureID_GuestFound(
            [Frozen] Mock<IAuthorizationQueries> authorizationQueries,
            AuthorizationManager authorizationManager,
            Account account,
            Guid azureID
            )
        {
            // Test data
            account.AzureID = azureID;
            account.IsAdminstrator = false;

            // Setup
            authorizationQueries.Setup(aq => aq.GetAccount(It.IsAny<Guid>())).Returns(account);

            // Act
            List<string> roles = authorizationManager.GetRoles(azureID.ToString());

            // Assert
            Assert.True(roles.Count == 0, "Expected a empty list of roles");

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void GetRoles_AzureID_NoAccountFound(
            [Frozen] Mock<IAuthorizationQueries> authorizationQueries,
            AuthorizationManager authorizationManager,
            Guid azureID
            )
        {
            // No Test data

            // Setup
            authorizationQueries.Setup(aq => aq.GetAccount(It.IsAny<Guid>())).Returns<Account>(null);

            // Act
            List<string> roles = authorizationManager.GetRoles(azureID.ToString());

            // Assert
            Assert.True(roles.Count == 0, "Expected a empty list of roles");

            // No Teardown
        }

        [Theory]
        [AutoDomainData]
        public void GetRoles_RandomString_NoRoles(
            [Frozen] Mock<IAuthorizationQueries> authorizationQueries,
            AuthorizationManager authorizationManager
            )
        {
            // Test data
            string randomID = "RandomID";

            // Setup
            authorizationQueries.Setup(aq => aq.GetAccount(It.IsAny<Guid>())).Returns<Account>(null);

            // Act
            List<string> roles = authorizationManager.GetRoles(randomID);

            // Assert
            Assert.True(roles.Count == 0, "Expected a empty list of roles");

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData("b5cca080-b4cf-4c7a-848a-c829e696ccb3", Roles.Adminstrator, "test@mad-world.nl", true, true)]
        [AutoDomainInlineData("b5cca080-b4cf-4c7a-848a-c829e696ccb3", Roles.Adminstrator, "test@mad-world.nl", false, false)]
        [AutoDomainInlineData("b5cca080-b4cf-4c7a-848a-c829e696ccb3", Roles.None, "test@mad-world.nl", false, true)]
        [AutoDomainInlineData("b5cca080-b4cf-4c7a-848a-c829e696ccb3", Roles.None, "test@mad-world.nl", true, true)]
        public void IsAuthorizated_AzureIDRoleEmail_Access(
            string azureID,
            Roles role,
            string email,
            bool isAdminstrator,
            bool expectedAccess,
            [Frozen] Mock<IAuthorizationQueries> authorizationQueries,
            AuthorizationManager authorizationManager,
            Account account,
            DataResult dataResult
            )
        {
            // Test data
            account.AzureID = Guid.Parse(azureID);
            account.IsAdminstrator = isAdminstrator;

            // Setup
            authorizationQueries.Setup(aq => aq.GetAccount(It.IsAny<Guid>())).Returns(account);
            authorizationQueries.Setup(aq => aq.AddAccount(It.IsAny<Guid>(), It.IsAny<string>())).Returns(dataResult);

            // Act
            bool hasAccess = authorizationManager.IsAuthorizated(azureID, role, email);

            // Assert
            Assert.Equal(expectedAccess, hasAccess);

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData("b5cca080-b4cf-4c7a-848a-c829e696ccb3", Roles.Adminstrator, "test@mad-world.nl", false, false)]
        [AutoDomainInlineData("b5cca080-b4cf-4c7a-848a-c829e696ccb3", Roles.None, "test@mad-world.nl", false, true)]
        public void IsAuthorizated_AzureIDRoleEmail_AccessWithCreatingAccount(
            string azureID,
            Roles role,
            string email,
            bool isAdminstrator,
            bool expectedAccess,
            [Frozen] Mock<IAuthorizationQueries> authorizationQueries,
            AuthorizationManager authorizationManager,
            Account account,
            DataResult dataResult
            )
        {
            // Test data
            account.AzureID = Guid.Parse(azureID);
            account.IsAdminstrator = isAdminstrator;
            Account? emptyAccount = null;

            // Setup
            authorizationQueries.SetupSequence(aq => aq.GetAccount(It.IsAny<Guid>()))
                                .Returns(emptyAccount)
                                .Returns(account);
            authorizationQueries.Setup(aq => aq.AddAccount(It.IsAny<Guid>(), It.IsAny<string>())).Returns(dataResult);

            // Act
            bool hasAccess = authorizationManager.IsAuthorizated(azureID, role, email);

            // Assert
            Assert.Equal(expectedAccess, hasAccess);

            // No Teardown
        }

        [Theory]
        [AutoDomainInlineData("RandomID", Roles.Adminstrator, "test@mad-world.nl", false)]
        [AutoDomainInlineData("RandomID", Roles.None, "test@mad-world.nl", false)]
        public void IsAuthorizated_WrongAzureIDRoleEmail_AccessWithCreatingAccount(
            string azureID,
            Roles role,
            string email,
            bool expectedAccess,
            AuthorizationManager authorizationManager
            )
        {
            // No Test data

            // Setup

            // Act
            bool hasAccess = authorizationManager.IsAuthorizated(azureID, role, email);

            // Assert
            Assert.Equal(expectedAccess, hasAccess);

            // No Teardown
        }
    }
}

