using System;
namespace MadWorld.Shared.Models.Admin
{
    public class UserResponse : BaseResponse
    {
        public Guid? ID { get; set; }
        public string Email { get; set; } = string.Empty;
        public bool IsAdmin { get; set; }
    }
}

