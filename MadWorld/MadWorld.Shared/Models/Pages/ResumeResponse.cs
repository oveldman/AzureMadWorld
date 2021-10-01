using System;
namespace MadWorld.Shared.Models.Pages
{
    public class ResumeResponse : BaseResponse
    {
        public int Age { get; set; }
        public string FullName { get; set; }
        public string Nationality { get; set; }
    }
}
