using CaptureRegionWPF.Enums;
using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureRegionWPF.Capture
{
    static class GraphicsExtensions
    {
        public static ImageFormat ToDrawingImageFormat(this ImageFormats Format)
        {
            switch (Format)
            {
                case ImageFormats.Jpg:
                    return ImageFormat.Jpeg;

                case ImageFormats.Png:
                    return ImageFormat.Png;

                case ImageFormats.Gif:
                    return ImageFormat.Gif;

                case ImageFormats.Bmp:
                    return ImageFormat.Bmp;

                default:
                    return ImageFormat.Png;
            }
        }
    }
}
