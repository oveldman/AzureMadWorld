using System;
using System.Collections.Generic;
using MadWorld.Console.Insight;
using MadWorld.Console.Insight.Interfaces;
using MadWorld.Console.Insight.Models;
using MadWorld.DataLayer.AzureBlob;
using MadWorld.DataLayer.AzureBlob.Interfaces;
using MadWorld.Optional;
using MadWorld.Optional.Interfaces;

namespace MadWorld.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IOption<int> some = Option<int>.CreateSome(10);
            IOption<int> none = Option<int>.CreateNone();

            if (some.HasValue)
            {
                System.Console.WriteLine($"Some: {some.GetValue()}");
            }

            System.Console.WriteLine($"None has value: {none.HasValue}");

            string test = none.Match<string>(t => t.ToString(), Lolz);

            System.Console.WriteLine($"Calc: {test}");

            /*
            IBlobManager storageManager = new BlobManager("UseDevelopmentStorage=true", "madworld");
            string filename = "test.txt";
            string filePath = "testpath/testpath";
            string filebody = "tekst tekst";
            storageManager.UploadFile(filename, filePath, filebody);
            string result = storageManager.DownloadStringFile(filename, "");
            */
        }

        public static string Lolz()
        {
            return "Yeah!";
        }
    }
}
