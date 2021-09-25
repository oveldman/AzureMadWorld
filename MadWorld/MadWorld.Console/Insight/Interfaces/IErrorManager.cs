using System;
using System.Collections.Generic;
using MadWorld.Console.Insight.Models;

namespace MadWorld.Console.Insight.Interfaces
{
    public interface IErrorManager
    {
        List<Error> GetErrors();
    }
}
