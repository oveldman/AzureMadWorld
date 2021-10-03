using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Form;
using MadWorld.Shared.Models.Pages.Support;
using Microsoft.AspNetCore.Components.Forms;

namespace MadWorld.Website.Pages.Support
{
    public partial class ReportBug
    {
        private bool Wait { get; set; }
        private bool ShowError { get; set; }
        private string ErrorMessage { get; set; } = string.Empty;

        private bool UserFinished { get; set; }
        private SecurityReportRequest SecurityReport = new();
        private readonly int MaxSize = 10240000;

        private async Task AddAttachments(InputFileChangeEventArgs e)
        {
            SecurityReport.Attachments = new();
            IReadOnlyList<IBrowserFile> attachments = e.GetMultipleFiles();
            foreach(IBrowserFile attachment in attachments)
            {
                SecurityReport.Attachments.Add(await CreateFile(attachment));
            }
        }

        private async Task AddPgpPublicKey(InputFileChangeEventArgs e)
        {
            SecurityReport.PgpPublicKey = new();

            IBrowserFile publicKey = e.File;
            SecurityReport.PgpPublicKey = await CreateFile(publicKey);
        }

        private async Task<UploadFile> CreateFile(IBrowserFile file)
        {
            StreamContent fileContent = new StreamContent(file.OpenReadStream(MaxSize));
            byte[] body = await fileContent.ReadAsByteArrayAsync();

            return new UploadFile
            {
                BodyBase64 = Convert.ToBase64String(body),
                Name = file.Name,
                ContentType = file.ContentType
            };
        }

        private async Task SendReport()
        {
            Reset();
            Wait = true;
            BaseResponse response = await _securityService.SendReport(SecurityReport);
            UserFinished = !response.Error;
            ShowError = response.Error;
            ErrorMessage = ShowError ? response.ErrorMessage : string.Empty;
            if (UserFinished) SecurityReport = new();
            Wait = false;
        }

        private void Reset()
        {
            ShowError = false;
            ErrorMessage = string.Empty;
            Wait = false;
        }
    }
}
