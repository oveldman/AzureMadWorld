using System;
using System.Collections.Generic;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries
{
    public class SecurityReportQueries : ISecurityReportQueries
    {
        private MadWorldContext _context;

        public SecurityReportQueries(MadWorldContext context)
        {
            _context = Guard.Against.Null(context);
        }

        public DataResult Save(SecurityReport report)
        {
            _context.SecurityReports.Add(report);
            _context.SaveChanges();

            return new DataResult
            {
                RowID = report.ID
            };
        }

        public DataResult Save(List<SecurityReportAttachment> attachments)
        {
            _context.SecurityReportAttachments.AddRange(attachments);
            _context.SaveChanges();

            return new DataResult();
        }

        public DataResult Save(SecurityReportAttachment attachment)
        {
            if (attachment is null)
            {
                return new DataResult()
                {
                    Error = true,
                    ErrorMessage = "Attachment cannot be null"
                };
            }

            return Save(new List<SecurityReportAttachment> { attachment });
        }

        public bool HasReportSlotsLeft(string ipAddress)
        {
            if (string.IsNullOrEmpty(ipAddress))
            {
                return false;
            }

            return _context.SecurityReports.Where(s => !s.IsVerified && s.ClientIpAddress == ipAddress).Count() < 6;
        }
    }
}
