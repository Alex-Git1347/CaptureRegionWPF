using CaptureRegionWPF.Interfaces;
using CaptureRegionWPF.Providers;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Prism.Ioc;

namespace CaptureRegionWPF.Capture
{
    public class ScreenShot
    {
        /// <summary>
        /// Captures the entire Desktop.
        /// </summary>
        /// <param name="IncludeCursor">Whether to include the Mouse Cursor.</param>
        /// <returns>The Captured Image.</returns>
        public static IBitmapImage Capture(bool IncludeCursor = false)
        {
            var platformServices = ContainerLocator.Container.Resolve<IPlatformServices>(); 
            //ServiceProvider.Get<IPlatformServices>();

            return Capture(platformServices.DesktopRectangle, IncludeCursor);
        }

        /// <summary>
        /// Capture transparent Screenshot of a Window.
        /// </summary>
        /// <param name="Window">The <see cref="IWindow"/> to Capture.</param>
        /// <param name="IncludeCursor">Whether to include Mouse Cursor.</param>
        public static IBitmapImage CaptureTransparent(IWindow Window, bool IncludeCursor = false)
        {
            var platformServices = ContainerLocator.Container.Resolve<IPlatformServices>();

            return platformServices.CaptureTransparent(Window, IncludeCursor);
        }

        static Bitmap CaptureInternal(Rectangle Region, bool IncludeCursor = false)
        {
            var bmp = new Bitmap(Region.Width, Region.Height);

            using (var g = Graphics.FromImage(bmp))
            {
                g.CopyFromScreen(Region.Location, Point.Empty, Region.Size, CopyPixelOperation.SourceCopy);

                if (IncludeCursor)
                    MouseCursor.Draw(g, P => new Point(P.X - Region.X, P.Y - Region.Y));

                g.Flush();
            }

            return bmp;
        }

        /// <summary>
        /// Captures a Specific Region.
        /// </summary>
        /// <param name="Region">A <see cref="Rectangle"/> specifying the Region to Capture.</param>
        /// <param name="IncludeCursor">Whether to include the Mouse Cursor.</param>
        /// <returns>The Captured Image.</returns>
        public static IBitmapImage Capture(Rectangle Region, bool IncludeCursor = false)
        {
            return new DrawingImage(CaptureInternal(Region, IncludeCursor));
        }
    }
}
