using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MadWorld.DataLayer.Database.Enum;

namespace MadWorld.DataLayer.Database.Tables
{
    public class BlobFile
    {
        [Key]
        public Guid ID { get; set; }
        [MaxLength(1000)]
        public string? ExternName { get; set; }
        public Guid BlobName { get; set; }
        [MaxLength(100)]
        public string? ContentType { get; set; }
        public SiteFileType FileType { get; set; }

        public virtual SecurityReport? SecurityReport { get; set; }
        public virtual List<SecurityReportAttachment>? SecurityReportAttachments { get; set; }
    }
}
