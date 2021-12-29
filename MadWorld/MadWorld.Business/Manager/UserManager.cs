using System;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin;

namespace MadWorld.Business.Manager
{
    public class UserManager : IUserManager
    {
        IUserManagmentQueries _userManagmentQueries;

        public UserManager(IUserManagmentQueries userManagmentQueries)
        {
            _userManagmentQueries = userManagmentQueries;
        }

        public UserResponse GetUser(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return new UserResponse
                {
                    Error = true,
                    ErrorMessage = "ID isn't valid"
                };
            }

            Account account = _userManagmentQueries.GetAccount(guid);

            if (account == null)
            {
                return new UserResponse
                {
                    Error = true,
                    ErrorMessage = "Account is not found"
                };
            }

            return new UserResponse
            {
                ID = account.ID,
                Email = account.EmailAdress,
                IsAdmin = account.IsAdminstrator
            };
        }

        public UsersResponse GetUsers()
        {
            List<Account> accounts = _userManagmentQueries.GetAccounts();

            return new UsersResponse
            {
                Users = accounts.Select(a => new UserDTO {
                    ID = a.ID,
                    Email = a.EmailAdress,
                    IsAdmin = a.IsAdminstrator
                }).ToList()
            };
        }

        public BaseResponse UpdateUser(UserDTO user)
        {
            Account account = _userManagmentQueries.GetAccount(user.ID);

            if (account == null)
            {
                return new BaseResponse
                {
                    Error = true,
                    ErrorMessage = "Account is not found"
                };
            }

            account.IsAdminstrator = user.IsAdmin;

            DataResult result = _userManagmentQueries.Update(account);
            return new BaseResponse
            {
                Error = result.Error,
                ErrorMessage = result.Error ? result.ErrorMessage = StandardErrorMessages.GeneralError : String.Empty
            };
        }
    }
}

