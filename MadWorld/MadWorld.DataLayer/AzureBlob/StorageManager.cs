using System;
using MadWorld.DataLayer.AzureBlob.Interfaces;

namespace MadWorld.DataLayer.AzureBlob
{
    public class StorageManager
    {
        private IBlobManager _blobManager;

        public StorageManager(IBlobManager blobManager)
        {
            _blobManager = blobManager;
        }
    }
}
