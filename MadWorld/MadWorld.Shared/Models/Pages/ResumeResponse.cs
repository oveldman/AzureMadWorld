using System;
namespace MadWorld.Shared.Web.Models.Pages
{
    public class ResumeResponse : BaseResponse
    {
        public int Age { get; set; }
        public string? FullName { get; set; } = string.Empty;
        public string? Nationality { get; set; } = string.Empty;
    }
}
