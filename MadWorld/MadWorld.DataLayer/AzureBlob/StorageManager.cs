using System;
using System.IO;
using MadWorld.DataLayer.AzureBlob.Interfaces;
using MadWorld.DataLayer.Database.Enum;

namespace MadWorld.DataLayer.AzureBlob
{
    public class StorageManager : IStorageManager
    {
        private IBlobManager _blobManager;

        public StorageManager(IBlobManager blobManager)
        {
            _blobManager = blobManager;
        }

        public DataResult DeleteFileIfExists(string filename, SiteFileType fileType)
        {
            return _blobManager.DeleteFileIfExists(GetFullPath(filename, fileType));
        }

        public byte[] DownloadByteFile(string filename, SiteFileType fileType)
        {
            return _blobManager.DownloadByteFile(GetFullPath(filename, fileType));
        }

        public Stream DownloadStreamFile(string filename, SiteFileType fileType)
        {
            return _blobManager.DownloadStreamFile(GetFullPath(filename, fileType));
        }

        public string DownloadStringFile(string filename, SiteFileType fileType)
        {
            return _blobManager.DownloadStringFile(GetFullPath(filename, fileType));
        }

        public DataResult UploadFile(string filename, SiteFileType fileType, byte[] file)
        {
            return _blobManager.UploadFile(GetFullPath(filename, fileType), file);
        }

        public DataResult UploadFile(string filename, SiteFileType fileType, MemoryStream file)
        {
            return _blobManager.UploadFile(GetFullPath(filename, fileType), file);
        }

        public DataResult UploadFile(string filename, SiteFileType fileType, string file)
        {
            return _blobManager.UploadFile(GetFullPath(filename, fileType), file);
        }

        private string GetFullPath(string filename, SiteFileType fileType)
        {
            string location = GetLocationPath(fileType);
            return Path.Combine(location, filename);
        }

        private string GetLocationPath(SiteFileType fileType)
        {
            switch (fileType)
            {
                case SiteFileType.Other: return "OtherFiles";
                case SiteFileType.PgpPublicKey: return "Security/PublicKeys";
                case SiteFileType.SecurityAttachment: return "Security/Attachments";
                default: throw new NotImplementedException();
            }
        }
    }
}
