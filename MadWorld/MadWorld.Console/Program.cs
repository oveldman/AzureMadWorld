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
            //Tester.TestBlob();
            Tester.TestGuard();
            //Tester.TestOption();
        }
    }
}
