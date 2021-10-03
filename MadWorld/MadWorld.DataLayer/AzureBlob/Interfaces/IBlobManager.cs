using System;
using System.IO;

namespace MadWorld.DataLayer.AzureBlob.Interfaces
{
    public interface IBlobManager
    {
        DataResult DeleteFileIfExists(string fullpath);
        byte[] DownloadByteFile(string filename, string location);
        byte[] DownloadByteFile(string fullPath);
        string DownloadStringFile(string filename, string location);
        string DownloadStringFile(string fullPath);
        Stream DownloadStreamFile(string filename, string location);
        Stream DownloadStreamFile(string fullPath);
        DataResult UploadFile(string filename, string location, byte[] file);
        DataResult UploadFile(string fullpath, byte[] file);
        DataResult UploadFile(string filename, string location, MemoryStream file);
        DataResult UploadFile(string fullpath, MemoryStream file);
        DataResult UploadFile(string filename, string location, string file);
        DataResult UploadFile(string fullpath, string file);
    }
}
