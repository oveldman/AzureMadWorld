using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MadWorld.DataLayer.Database.Tables
{
    public class SecurityReport
    {
        [Key]
        public Guid ID { get; set; }
        [MaxLength(100)]
        public string FullName { get; set; }
        [MaxLength(100)]
        public string Email { get; set; }
        [MaxLength(100)]
        public string Title { get; set; }
        [MaxLength(10000)]
        public string Description { get; set; }
        [ForeignKey("BlobFile")]
        public Guid? PublicKeyID { get; set; }

        public virtual BlobFile PublicKeyFile { get; set; }
        public virtual List<SecurityReportAttachment> Attachments { get; set; }
    }
}
