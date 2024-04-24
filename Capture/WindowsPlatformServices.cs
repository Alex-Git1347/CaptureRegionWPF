using CaptureRegionWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureRegionWPF.Capture
{
    public class WindowsPlatformServices : IPlatformServices
    {
        public IWindow DesktopWindow => Window.DesktopWindow;

        public IWindow ForegroundWindow => Window.ForegroundWindow;

        public Rectangle DesktopRectangle => SystemInformation.VirtualScreen;

        public Point CursorPosition
        {
            get
            {
                var p = new Point();
                User32.GetCursorPos(ref p);
                return p;
            }
        }

        public IBitmapImage Capture(Rectangle Region, bool IncludeCursor = false)
        {
            return ScreenShot.Capture(Region, IncludeCursor);
        }

        public IBitmapImage CaptureTransparent(IWindow Window, bool IncludeCursor = false)
        {
            throw new NotImplementedException();
        }

        public bool DeleteFile(string FilePath)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWindow> EnumerateAllWindows()
        {
            return Window.EnumerateVisible();
        }

        public IEnumerable<IScreen> EnumerateScreens()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<IWindow> EnumerateWindows()
        {
            throw new NotImplementedException();
        }

        public IImageProvider GetAllScreensProvider(bool IncludeCursor, bool StepsMode)
        {
            throw new NotImplementedException();
        }

        public IImageProvider GetRegionProvider(Rectangle Region, bool IncludeCursor, Func<Point> LocationFunction = null)
        {
            throw new NotImplementedException();
        }

        public IImageProvider GetScreenProvider(IScreen Screen, bool IncludeCursor, bool StepsMode)
        {
            throw new NotImplementedException();
        }

        public IWindow GetWindow(IntPtr Handle)
        {
            throw new NotImplementedException();
        }

        public IImageProvider GetWindowProvider(IWindow Window, bool IncludeCursor)
        {
            throw new NotImplementedException();
        }
    }
}
