using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CaptureRegionWPF.Capture
{
    public class Kernel32
    {
        const string DllName = "Kernel32";

        [DllImport(DllName)]
        public static extern void CopyMemory(IntPtr Dest, IntPtr Src, int Count);
    }
}
