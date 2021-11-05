using System;
using System.Collections.Generic;
using MadWorld.API.Attribute;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.Database.Enum;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MadWorld.API.Controllers.Admin
{
    [AuthorizeMW(Roles.Adminstrator)]
    [ApiController]
    [Route("Admin/[controller]")]
    public class UserController : ControllerBase
    {
        IUserManager _userManager;

        public UserController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        [Route("GetUsers")]
        public UsersResponse GetUsers()
        {
            return _userManager.GetUsers();
        }

        [HttpGet]
        [Route("GetUser")]
        public UserResponse GetUser(string id)
        {
            return _userManager.GetUser(id);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public BaseResponse UpdateUser(UserDTO user)
        {
            return _userManager.UpdateUser(user);
        }
    }
}

