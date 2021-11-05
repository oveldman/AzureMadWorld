using System;
using System.Collections.Generic;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries.Interfaces
{
    public interface IUserManagmentQueries
    {
        List<Account> GetAccounts();
        Account GetAccount(Guid id);
        DataResult Update(Account account);
    }
}

