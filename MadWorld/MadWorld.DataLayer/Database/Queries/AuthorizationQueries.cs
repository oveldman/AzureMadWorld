using System;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries
{
    public class AuthorizationQueries : IAuthorizationQueries
    {
        private MadWorldContext _context;

        public AuthorizationQueries(MadWorldContext context)
        {
            _context = context;
        }

        public DataResult AddAccount(Guid azureID, string email)
        {
            Account account = new Account
            {
                AzureID = azureID,
                EmailAdress = email
            };

            _context.Accounts.Add(account);
            _context.SaveChanges();

            return new DataResult();
        }

        public Account GetAccount(Guid azureID)
        {
            return _context.Accounts.FirstOrDefault(a => a.AzureID == azureID);
        }
    }
}

