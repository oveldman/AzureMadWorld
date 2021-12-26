using System;
using System.Collections.Generic;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using Microsoft.Extensions.Logging;

namespace MadWorld.DataLayer.Database.Queries
{
    public class UserManagmentQueries : IUserManagmentQueries
    {
        private ILogger<UserManagmentQueries> _logger;
        private MadWorldContext _context;

        public UserManagmentQueries(MadWorldContext context, ILogger<UserManagmentQueries> logger)
        {
            _context = context;
            _logger = logger;
        }

        public Account GetAccount(Guid id)
        {
            return _context.Accounts.FirstOrDefault(a => a.ID == id);
        }

        public List<Account> GetAccounts()
        {
            return _context.Accounts.ToList();
        }

        public DataResult Update(Account account)
        {
            try
            {
                _context.Accounts.Update(account);
                _context.SaveChanges();
            }
            catch(Exception exception)
            {
                _logger.LogError(new EventId(), exception, "Account ID: {account.ID} didn't save", account.ID);

                return new DataResult
                {
                    Error = true,
                    ErrorMessage = "Account didn't save"
                };
            }

            return new DataResult();
        }
    }
}

