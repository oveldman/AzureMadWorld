using System;
using System.Threading.Tasks;
using MadWorld.Shared.Web.Models.Pages;

namespace MadWorld.Website.Services.Interfaces
{
    public interface IResumeService
    {
        Task<ResumeResponse> Get();
    }
}
