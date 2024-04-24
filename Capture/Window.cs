using CaptureRegionWPF.Enums;
using CaptureRegionWPF.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CaptureRegionWPF.Capture
{
    public class Window : IWindow
    {
        public Window(IntPtr Handle)
        {
            if (!User32.IsWindow(Handle))
                throw new ArgumentException("Not a Window.", nameof(Handle));

            this.Handle = Handle;
        }

        public IntPtr Handle { get; }

        public static Window DesktopWindow { get; } = new Window(User32.GetDesktopWindow());

        public static Window ForegroundWindow => new Window(User32.GetForegroundWindow());

        public bool IsAlive => User32.IsWindow(Handle);

        public bool IsVisible => User32.IsWindowVisible(Handle);

        public bool IsMaximized => User32.IsZoomed(Handle);

        public string Title
        {
            get
            {
                var title = new StringBuilder(User32.GetWindowTextLength(Handle) + 1);
                User32.GetWindowText(Handle, title, title.Capacity);
                return title.ToString();
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                var r = new RECT();

                const int extendedFrameBounds = 9;

                if (DwmApi.DwmGetWindowAttribute(Handle, extendedFrameBounds, ref r, Marshal.SizeOf<RECT>()) != 0)
                {
                    if (!User32.GetWindowRect(Handle, out r))
                        return Rectangle.Empty;
                }

                return r.ToRectangle();
            }
        }

        public static IEnumerable<Window> Enumerate()
        {
            var list = new List<Window>();

            User32.EnumWindows((Handle, Param) =>
            {
                var wh = new Window(Handle);

                list.Add(wh);

                return true;
            }, IntPtr.Zero);

            return list;
        }

        public static IEnumerable<Window> EnumerateVisible()
        {
            foreach (var window in Enumerate().Where(W => W.IsVisible && !string.IsNullOrWhiteSpace(W.Title)))
            {
                var hWnd = window.Handle;

                if (!User32.GetWindowLong(hWnd, GetWindowLongValue.ExStyle).HasFlag(WindowStyles.AppWindow))
                {
                    if (User32.GetWindow(hWnd, GetWindowEnum.Owner) != IntPtr.Zero)
                        continue;

                    if (User32.GetWindowLong(hWnd, GetWindowLongValue.ExStyle).HasFlag(WindowStyles.ToolWindow))
                        continue;

                    if (User32.GetWindowLong(hWnd, GetWindowLongValue.Style).HasFlag(WindowStyles.Child))
                        continue;
                }

                const int dwmCloaked = 14;

                // Exclude suspended Windows apps
                DwmApi.DwmGetWindowAttribute(hWnd, dwmCloaked, out var cloaked, Marshal.SizeOf<bool>());

                if (cloaked)
                    continue;

                yield return window;
            }
        }
    }
}
