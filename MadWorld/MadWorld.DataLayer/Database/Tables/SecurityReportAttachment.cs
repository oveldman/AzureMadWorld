using System;
namespace MadWorld.DataLayer.Database.Tables
{
    public class SecurityReportAttachment
    {
        public Guid SecurityReportID { get; set; }
        public Guid BlobFileID { get; set; }

        public virtual SecurityReport SecurityReport { get; set; }
        public virtual BlobFile BlobFile { get; set; }
    }
}
