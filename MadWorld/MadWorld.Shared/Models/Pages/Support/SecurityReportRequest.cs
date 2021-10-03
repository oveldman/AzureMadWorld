using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MadWorld.Shared.Models.Form;

namespace MadWorld.Shared.Models.Pages.Support
{
    public class SecurityReportRequest
    {
        public string Email { get; set; }
        public string Fullname { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        public UploadFile PgpPublicKey { get; set; }
        public List<UploadFile> Attachments { get; set; }
    }
}
