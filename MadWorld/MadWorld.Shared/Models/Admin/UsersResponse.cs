using System;
using System.Collections.Generic;

namespace MadWorld.Shared.Web.Models.Admin
{
    public class UsersResponse : BaseResponse
    {
        public List<UserDTO> Users { get; set; } = new();
    }
}

