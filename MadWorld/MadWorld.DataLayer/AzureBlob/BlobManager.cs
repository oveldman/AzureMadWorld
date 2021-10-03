using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using MadWorld.DataLayer.AzureBlob.Interfaces;
using System;
using System.IO;
using System.Text;

namespace MadWorld.DataLayer.AzureBlob
{
    public class BlobManager : IBlobManager
    {
        private readonly BlobServiceClient _serviceClient;
        private readonly BlobContainerClient _containerClient;

        public BlobManager(string blobConnectionString, string containerName)
        {
            _serviceClient = new BlobServiceClient(blobConnectionString);
            _containerClient = _serviceClient.GetBlobContainerClient(containerName);
            _containerClient.CreateIfNotExists();
        }

        public DataResult DeleteFileIfExists(string fullpath)
        {
            _containerClient.DeleteBlobIfExists(fullpath);
            return new DataResult();
        }

        public byte[] DownloadByteFile(string filename, string location)
        {
            string fullPath = Path.Combine(location, filename);
            return DownloadByteFile(fullPath);
        }

        public byte[] DownloadByteFile(string fullPath)
        {
            MemoryStream memoryStream = new();
            Stream file = DownloadStreamFile(fullPath);

            if (file is null) return Array.Empty<byte>();

            file.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }

        public string DownloadStringFile(string filename, string location)
        {
            string fullPath = Path.Combine(location, filename);
            return DownloadStringFile(fullPath);
        }

        public string DownloadStringFile(string fullPath)
        {
            byte[] file = DownloadByteFile(fullPath);
            return Encoding.UTF8.GetString(file);
        }

        public Stream DownloadStreamFile(string filename, string location)
        {
            string fullPath = Path.Combine(location, filename);
            return DownloadStreamFile(fullPath);
        }

        public Stream DownloadStreamFile(string fullPath)
        {
            BlobClient client = _containerClient.GetBlobClient(fullPath);
            Response<BlobDownloadResult> response;

            try
            {
                response = client.DownloadContent();
            }
            catch (Exception)
            {
                return null;
            }

            return response.Value.Content.ToStream();
        }

        public DataResult UploadFile(string fullpath, byte[] file)
        {
            return UploadFile(fullpath, new MemoryStream(file));
        }

        public DataResult UploadFile(string filename, string location, byte[] file)
        {
            string fullPath = Path.Combine(location, filename);
            return UploadFile(fullPath, file);
        }

        public DataResult UploadFile(string filename, string location, MemoryStream file)
        {
            string fullPath = Path.Combine(location, filename);
            return UploadFile(fullPath, file);
        }

        public DataResult UploadFile(string fullpath, MemoryStream file)
        {
            if (!DeleteFileIfExists(fullpath).Error)
            {
                Response<BlobContentInfo> response = _containerClient.UploadBlob(fullpath, file);
                return new DataResult();
            }

            return new DataResult()
            {
                Error = true,
                ErrorMessage = "Old file couldn't be deleted. "
            };
        }

        public DataResult UploadFile(string filename, string location, string file)
        {
            string fullPath = Path.Combine(location, filename);
            return UploadFile(fullPath, file);
        }

        public DataResult UploadFile(string fullpath, string file)
        {
            return UploadFile(fullpath, Encoding.UTF8.GetBytes(file));
        }
    }
}
