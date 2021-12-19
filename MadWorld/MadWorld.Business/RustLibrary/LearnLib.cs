using System;
using System.Runtime.InteropServices;

namespace MadWorld.Business.RustLibrary
{
    public class LearnLib
    {
        // Return data in method result
        [DllImport("learn_lib")]
        public static extern int plus(int x, int y);
    }
}

