using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace CaptureRegionWPF.Interfaces
{
    public interface IImageProvider : IDisposable
    {
        /// <summary>
        /// Capture an image.
        /// </summary>
        IEditableFrame Capture();

        /// <summary>
        /// Height of Captured image.
        /// </summary>
        int Height { get; }

        /// <summary>
        /// Width of Captured image.
        /// </summary>
        int Width { get; }

        Func<Point, Point> PointTransform { get; }

        IBitmapFrame DummyFrame { get; }
    }
}
