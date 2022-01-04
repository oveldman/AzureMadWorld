using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.Shared.Models.Form
{
    public class UploadFile
    {
        [Required]
        public string BodyBase64 { get; set; } = string.Empty;
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string ContentType { get; set; } = string.Empty;
    }
}
