using System;
using System.Collections.Generic;
using MadWorld.API.Attribute;
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

        public UserController()
        {
        }

        [HttpGet]
        [Route("GetUsers")]
        public UsersResponse GetUsers()
        {
            return new UsersResponse
            {
                Users = new List<UserDTO> {
                    new UserDTO
                    {
                        ID = Guid.NewGuid(),
                        Email = "test@test.nl",
                        IsAdmin = true
                    }
                }
            };
        }

        [HttpPatch]
        [Route("UpdateUser")]
        public BaseResponse UpdateUser(UserDTO user)
        {
            return new BaseResponse
            {
            };
        }
    }
}

