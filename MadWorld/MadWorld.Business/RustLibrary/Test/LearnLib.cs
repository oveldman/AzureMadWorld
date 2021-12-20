using System;
using System.Runtime.InteropServices;

namespace MadWorld.Business.RustLibrary.Test
{
    public class LearnLib
    {
        private const string libraryName = "learn_lib";

        // Return data in method result
        [DllImport(libraryName)]
        public static extern int plus(int x, int y);

        [DllImport(libraryName)]
        public static extern TestStruct test_struct_plus(int x, int y);

        [DllImport(libraryName)]
        public static extern StringStruct test_struct_string();
    }
}

