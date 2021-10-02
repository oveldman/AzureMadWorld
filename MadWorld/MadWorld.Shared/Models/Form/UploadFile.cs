using System;
namespace MadWorld.Shared.Models.Form
{
    public class UploadFile
    {
        public string BodyBase64 { get; set; }
        public string Name { get; set; }
        public string ContentType { get; set; }
    }
}
