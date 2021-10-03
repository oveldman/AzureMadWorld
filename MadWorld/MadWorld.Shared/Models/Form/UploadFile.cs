using System;
using System.ComponentModel.DataAnnotations;

namespace MadWorld.Shared.Models.Form
{
    public class UploadFile
    {
        [Required]
        public string BodyBase64 { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string ContentType { get; set; }
    }
}
