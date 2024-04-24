using CaptureRegionWPF.Enums;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureRegionWPF.Interfaces
{
    public interface IBitmapImage : IDisposable
    {
        int Width { get; }
        int Height { get; }

        void Save(string FileName, ImageFormats Format);

        void Save(Stream Stream, ImageFormats Format);
    }
}
