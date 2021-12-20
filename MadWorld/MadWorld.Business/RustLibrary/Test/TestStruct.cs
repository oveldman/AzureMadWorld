using System;
using System.Runtime.InteropServices;

namespace MadWorld.Business.RustLibrary.Test
{
	[StructLayout(LayoutKind.Sequential)]
	public struct TestStruct
	{
		public int id { get; set; }
		public int answer { get; set; }
	}
}

