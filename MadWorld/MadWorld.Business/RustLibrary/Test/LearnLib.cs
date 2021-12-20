using System;
using System.Runtime.InteropServices;

namespace MadWorld.Business.RustLibrary.Test
{
    public class LearnLib
    {
        // Return data in method result
        [DllImport("learn_lib")]
        public static extern int plus(int x, int y);

        [DllImport("learn_lib")]
        public static extern TestStruct test_struct_plus(int x, int y);

        [DllImport("learn_lib")]
        public static extern StringStruct test_struct_string();
    }
}

