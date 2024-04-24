using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureRegionWPF.Interfaces
{
    public interface IBitmapFrame : IDisposable
    {
        int Width { get; }

        int Height { get; }

        void CopyTo(byte[] Buffer);

        void CopyTo(IntPtr Buffer);

        TimeSpan Timestamp { get; }
    }
}
