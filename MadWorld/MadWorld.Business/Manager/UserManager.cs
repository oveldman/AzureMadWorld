using System;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Web.Creators;
using MadWorld.Shared.Web.Models;
using MadWorld.Shared.Web.Models.Admin;

namespace MadWorld.Business.Manager
{
    public class UserManager : IUserManager
    {
        IUserManagmentQueries _userManagmentQueries;

        public UserManager(IUserManagmentQueries userManagmentQueries)
        {
            _userManagmentQueries = Guard.Against.Null(userManagmentQueries);
        }

        public UserResponse GetUser(string id)
        {
            if (!Guid.TryParse(id, out Guid guid))
            {
                return ResponseCreators.CreateErrorResponse<UserResponse>("ID isn't valid");
            }

            Account account = _userManagmentQueries.GetAccount(guid);

            if (account == null)
            {
                return ResponseCreators.CreateErrorResponse<UserResponse>("Account is not found");
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
                Users = CreateUsersDTO(accounts)
            };
        }

        public BaseResponse UpdateUser(UserDTO user)
        {
            Account account = _userManagmentQueries.GetAccount(user.ID);

            if (account == null)
            {
                return ResponseCreators.CreateErrorResponse<BaseResponse>("Account is not found");
            }

            account.IsAdminstrator = user.IsAdmin;

            DataResult result = _userManagmentQueries.Update(account);
            return new BaseResponse
            {
                Error = result.Error,
                ErrorMessage = result.Error ? result.ErrorMessage = StandardErrorMessages.GeneralError : String.Empty
            };
        }

        private List<UserDTO> CreateUsersDTO(List<Account> accounts)
        {
            return accounts.Select(a => new UserDTO
            {
                ID = a.ID,
                Email = a.EmailAdress,
                IsAdmin = a.IsAdminstrator
            }).ToList();
        }
    }
}

