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
            var test = new TimeSpan(0, 0, 5);
            var lolz = test.TotalMilliseconds;

            //Tester.TestBlob();
            //Tester.TestGuard();
            //Tester.TestOperator();
            //Tester.TestOption();
        }
    }
}
