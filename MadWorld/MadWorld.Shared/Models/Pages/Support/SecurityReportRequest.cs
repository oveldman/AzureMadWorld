using System;
using System.Collections.Generic;
using MadWorld.Shared.Models.Form;

namespace MadWorld.Shared.Models.Pages.Support
{
    public class SecurityReportRequest
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public UploadFile PgpPublicKey { get; set; }
        public List<UploadFile> Attachments { get; set; }
    }
}
