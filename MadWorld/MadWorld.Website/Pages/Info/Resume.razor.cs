using System;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models.Pages;

namespace MadWorld.Website.Pages.Info
{
    public partial class Resume
    {
        private ResumeResponse resumeResponse = new();

        protected override async Task OnInitializedAsync()
        {
            resumeResponse = await _resumeService.Get();
        }
    }
}
