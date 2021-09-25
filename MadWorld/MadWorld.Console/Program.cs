using System;
using System.Collections.Generic;
using MadWorld.Console.Insight;
using MadWorld.Console.Insight.Interfaces;
using MadWorld.Console.Insight.Models;

namespace MadWorld.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            IErrorManager errorManager = new ErrorManager();
            List<Error> errors = errorManager.GetErrors();
        }
    }
}
