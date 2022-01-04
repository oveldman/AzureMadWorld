using System;
using System.Threading.Tasks;
using MadWorld.DataLayer.Database.Tables;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace MadWorld.DataLayer.Database
{
    public class MadWorldContext : DbContext
    {
        private const int TimeoutDuration = 10 * 60;

        public MadWorldContext(DbContextOptions options) : base(options) 
        {
            this.Database.SetCommandTimeout(TimeoutDuration);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SecurityReport>()
                .HasOne(s => s.PublicKeyFile)
                .WithOne(bf => bf.SecurityReport)
                .HasForeignKey<SecurityReport>(s => s.PublicKeyID);

            modelBuilder.Entity<SecurityReportAttachment>()
                .HasOne(sra => sra.SecurityReport)
                .WithMany(sr => sr.Attachments)
                .HasForeignKey(sra => sra.SecurityReportID);

            modelBuilder.Entity<SecurityReportAttachment>()
                .HasOne(sra => sra.BlobFile)
                .WithMany(sr => sr.SecurityReportAttachments)
                .HasForeignKey(sra => sra.BlobFileID);
        }

        public DbSet<Account>? Accounts { get; set; }
        public DbSet<BlobFile>? Files { get; set; }
        public DbSet<IpfsFile>? IpfsFiles { get; set; }
        public DbSet<Resume>? Resumes { get; set; }
        public DbSet<SecurityReport>? SecurityReports { get; set; }
        public DbSet<SecurityReportAttachment>? SecurityReportAttachments { get; set; }
    }
}
