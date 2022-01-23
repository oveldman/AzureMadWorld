using System;
namespace MadWorld.Shared.Web.Models
{
    public class BaseResponse
    {
        public bool Error { get; set; }
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
