using System;
using System.Drawing;
using System.Runtime.InteropServices;

namespace CaptureRegionWPF.Structs
{
    [StructLayout(LayoutKind.Sequential)]
    struct CursorInfo
    {
        public int cbSize;
        public int flags;
        public IntPtr hCursor;
        public Point ptScreenPos;
    }
}
