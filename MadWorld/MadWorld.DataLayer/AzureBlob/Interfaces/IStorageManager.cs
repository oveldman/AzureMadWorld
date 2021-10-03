using System;
using System.IO;
using MadWorld.DataLayer.Database.Enum;

namespace MadWorld.DataLayer.AzureBlob.Interfaces
{
    public interface IStorageManager
    {
        DataResult DeleteFileIfExists(string filename, SiteFileType fileType);
        byte[] DownloadByteFile(string filename, SiteFileType fileType);
        string DownloadStringFile(string filename, SiteFileType fileType);
        Stream DownloadStreamFile(string filename, SiteFileType fileType);
        DataResult UploadFile(string filename, SiteFileType fileType, byte[] file);
        DataResult UploadFile(string filename, SiteFileType fileType, MemoryStream file);
        DataResult UploadFile(string filename, SiteFileType fileType, string file);
    }
}
