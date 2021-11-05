using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.Shared.Models.Admin
{
    public class UserDTO
    {
        [Required]
        public Guid ID { get; set; }
        public string Email { get; set; }
        public bool IsAdmin { get; set; }
    }
}

