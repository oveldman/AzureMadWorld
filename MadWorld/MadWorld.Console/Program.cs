using System;
using System.Collections.Generic;
using MadWorld.Console.Insight;
using MadWorld.Console.Insight.Interfaces;
using MadWorld.Console.Insight.Models;
using MadWorld.DataLayer.AzureBlob;
using MadWorld.DataLayer.AzureBlob.Interfaces;

namespace MadWorld.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IBlobManager storageManager = new BlobManager("UseDevelopmentStorage=true", "madworld");
            string filename = "test.txt";
            string filePath = "testpath/testpath";
            string filebody = "tekst tekst";
            storageManager.UploadFile(filename, filePath, filebody);
            string result = storageManager.DownloadStringFile(filename, "");
        }
    }
}
