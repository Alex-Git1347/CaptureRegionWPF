using System;
using System.Drawing;

namespace CaptureRegionWPF.Interfaces
{
    public interface IBitmapLoader : IDisposable
    {
        IBitmapImage CreateBitmapBgr32(Size Size, IntPtr MemoryData, int Stride);

        IBitmapImage LoadBitmap(string FileName);
    }
}
