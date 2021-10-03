using System;
using MadWorld.Business.Manager.Interfaces;
using MadWorld.DataLayer.AzureBlob.Interfaces;

namespace MadWorld.Business.Manager
{
    public class SecurityReportManager : ISecurityReportManager
    {
        private IStorageManager _storageManager;

        public SecurityReportManager(IStorageManager storageManager)
        {
            _storageManager = storageManager;
        }
    }
}
