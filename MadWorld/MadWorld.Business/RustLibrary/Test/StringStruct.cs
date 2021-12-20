using System;
using System.Runtime.InteropServices;

namespace MadWorld.Business.RustLibrary.Test
{
	public struct StringStruct
	{
		public int id { get; set; }
		public IntPtr answer { get; set; }
		public string AnswerToString
        {
			get
            {
				return Marshal.PtrToStringUTF8(answer);
			}
        }
	}
}

