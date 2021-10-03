using System;
using System.Collections.Generic;
using MadWorld.DataLayer.Database.Tables;

namespace MadWorld.DataLayer.Database.Queries.Interfaces
{
    public interface ISecurityReportQueries
    {
        DataResult Save(SecurityReport report);
        DataResult Save(SecurityReportAttachment attachment);
        DataResult Save(List<SecurityReportAttachment> attachments);
        bool HasReportSlotsLeft(string ipAddress);
    }
}
