using System;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries.Interfaces
{
    public interface IAuthorizationQueries
    {
        DataResult AddAccount(Guid azureID, string email);
        Account GetAccount(Guid azureID);
    }
}

