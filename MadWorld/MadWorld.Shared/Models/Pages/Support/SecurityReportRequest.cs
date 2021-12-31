using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MadWorld.Shared.Models.Form;

namespace MadWorld.Shared.Models.Pages.Support
{
    public class SecurityReportRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Fullname { get; set; } = string.Empty;
        [Required]
        public string Title { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public UploadFile PgpPublicKey { get; set; } = new();
        public List<UploadFile> Attachments { get; set; } = new();
    }
}
