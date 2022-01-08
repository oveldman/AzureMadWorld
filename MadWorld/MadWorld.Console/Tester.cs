using System;
using MadWorld.Console.GuardFolder;
using MadWorld.DataLayer.AzureBlob;
using MadWorld.DataLayer.AzureBlob.Interfaces;
using MadWorld.Guardian;
using MadWorld.Optional;
using MadWorld.Optional.Interfaces;

namespace MadWorld.Console
{
	public class Tester
	{
        #region Blob
        public static void TestBlob()
        {
            IBlobManager storageManager = new BlobManager("UseDevelopmentStorage=true", "madworld");
            string filename = "test.txt";
            string filePath = "testpath/testpath";
            string filebody = "tekst tekst";
            storageManager.UploadFile(filename, filePath, filebody);
            string result = storageManager.DownloadStringFile(filename, "");
        }
        #endregion

        #region Guard
        public static void TestGuard()
        {
            RandomGuardClass testData = new RandomGuardClass();
            RandomGuardClass test = Guard.Against.Null(testData, nameof(testData));
            testData = null;
            RandomGuardClass test2 = Guard.Against.Null(testData, nameof(testData));
        }
        #endregion

        #region Option
        public static void TestOption()
        {
            IOption<int> some = Option<int>.CreateSome(20);
            IOption<int> none = Option<int>.CreateNone();

            if (some.HasValue)
            {
                System.Console.WriteLine($"Some: {some.GetValue()}");
            }

            System.Console.WriteLine($"None has value: {none.HasValue}");

            string test = some.Match<string>(Found, NotFound);

            System.Console.WriteLine($"Calc: {test}");
        }

        public static string Found(int testValue)
        {
            return testValue.ToString();
        }

        public static string NotFound()
        {
            return "No Value found!";
        }

        #endregion
    }
}

