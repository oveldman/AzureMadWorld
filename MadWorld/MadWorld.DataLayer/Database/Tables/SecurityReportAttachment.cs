using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadWorld.DataLayer.Database.Tables
{
    public class SecurityReportAttachment
    {
        [Key]
        public Guid ID { get; set; }
        [ForeignKey("SecurityReport")]
        public Guid SecurityReportID { get; set; }
        [ForeignKey("BlobFile")]
        public Guid BlobFileID { get; set; }

        public virtual SecurityReport? SecurityReport { get; set; }
        public virtual BlobFile? BlobFile { get; set; }
    }
}
