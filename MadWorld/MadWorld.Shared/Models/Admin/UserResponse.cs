using System;
namespace MadWorld.Shared.Models.Admin
{
    public class UserResponse : BaseResponse
    {
        public Guid? ID { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}

