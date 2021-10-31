﻿using System;
using System.Collections.Generic;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer;
using MadWorld.DataLayer.Database.Enum;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.Business.Manager
{
    public class AuthorizationManager : IAuthorizationManager
    {
        private IAuthorizationQueries _authorizationQueries;

        public AuthorizationManager(IAuthorizationQueries authorizationQueries)
        {
            _authorizationQueries = authorizationQueries;
        }

        public List<string> GetRoles(string azureID)
        {
            List<string> roles = new();

            if (!Guid.TryParse(azureID, out Guid azureIDParsed))
            {
                return roles;
            }

            Account account = _authorizationQueries.GetAccount(azureIDParsed);

            if (account == null)
            {
                return roles;
            }

            if (account.IsAdminstrator)
            {
                roles.Add(Roles.Adminstrator.ToString());
            }

            return roles;
        }

        public bool IsAuthorizated(string azureID, Roles role, string email)
        {
            if (!Guid.TryParse(azureID, out Guid azureIDParsed))
            {
                return false;
            }

            Account account = _authorizationQueries.GetAccount(azureIDParsed);

            if (account == null)
            {
                DataResult result = _authorizationQueries.AddAccount(azureIDParsed, email);
                account = _authorizationQueries.GetAccount(azureIDParsed);
                if (result.Error) return false;
            }

            if (Roles.Adminstrator == role)
            {
                return account.IsAdminstrator;
            }

            return false;
        }
    }
}

