﻿using System;
using System.Collections.Generic;
using System.Linq;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer;
using MadWorld.DataLayer.AzureBlob.Interfaces;
using MadWorld.DataLayer.Database.Enum;
using MadWorld.DataLayer.Database.Queries.Interfaces;
using MadWorld.DataLayer.Database.Tables;
using MadWorld.Shared.Models;
using MadWorld.Shared.Models.Form;
using MadWorld.Shared.Models.Pages.Support;

namespace MadWorld.Business.Manager
{
    public class SecurityReportManager : ISecurityReportManager
    {
        private IBlobTableQueries _blobTableQueries;
        private ISecurityReportQueries _securityReportQueries;
        private IStorageManager _storageManager;

        public SecurityReportManager(IBlobTableQueries blobTableQueries,
            ISecurityReportQueries securityReportQueries,
            IStorageManager storageManager)
        {
            _blobTableQueries = blobTableQueries;
            _securityReportQueries = securityReportQueries;
            _storageManager = storageManager;
        }

        public BaseResponse Save(SecurityReportRequest report)
        {
            Guid? pgpKeyFileID = null;
            if (report.PgpPublicKey is not null)
            {
                DataResult keyResult = SavePublicKey(report.PgpPublicKey);
                pgpKeyFileID = keyResult.RowID;
            }

            DataResult reportResult = SaveReport(report, pgpKeyFileID);

            if (report?.Attachments.Any() ?? false && reportResult.Succeed)
            {
                SaveAttachments(report.Attachments, reportResult.RowID.Value);
            }

            return new BaseResponse()
            {
                Error = reportResult.Error,
                ErrorMessage = reportResult.Error ? "There went something wrong while saving your report" : string.Empty
            };
        }

        private DataResult SavePublicKey(UploadFile file)
        {
            SiteFileType fileType = SiteFileType.PgpPublicKey;
            Guid publicKeyFileName = Guid.NewGuid();

            DataResult result = _storageManager.UploadFile(publicKeyFileName.ToString(),
                fileType, Convert.FromBase64String(file.BodyBase64));

            if (result.Error) return result;

            return SaveBlobInDatabase(file, publicKeyFileName, fileType);
        }

        private DataResult SaveReport(SecurityReportRequest report, Guid? pgpKeyFileID)
        {
            SecurityReport securityReport = new()
            {
                Description = report.Description,
                Email = report.Email,
                FullName = report.Fullname,
                PublicKeyID = pgpKeyFileID,
                Title = report.Title
            };

            return _securityReportQueries.Save(securityReport);
        }

        private DataResult SaveAttachments(List<UploadFile> files, Guid reportID)
        {
            SiteFileType fileType = SiteFileType.SecurityAttachment;
            List<SecurityReportAttachment> attachments = new();

            foreach (UploadFile file in files)
            {
                Guid attachmentFileName = Guid.NewGuid();
                DataResult result = _storageManager.UploadFile(attachmentFileName.ToString(),
                    fileType, Convert.FromBase64String(file.BodyBase64));

                if (result.Error) continue;

                DataResult blobResult = SaveBlobInDatabase(file, attachmentFileName, fileType);

                if (result.Error) continue;

                SecurityReportAttachment attachment = new()
                {
                    SecurityReportID = reportID,
                    BlobFileID = blobResult.RowID.Value
                };
                attachments.Add(attachment);
            }

            return _securityReportQueries.Save(attachments);
        }

        private DataResult SaveBlobInDatabase(UploadFile file, Guid filename, SiteFileType fileType)
        {
            BlobFile blobFile = new()
            {
                BlobName = filename,
                ContentType = file.ContentType,
                ExternName = file.Name,
                FileType = fileType,
            };

            return _blobTableQueries.SaveFile(blobFile);
        }
    }
}