using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaptureRegionWPF.Capture
{
    static class NativeExtensions
    {
        public static Rectangle ToRectangle(this RECT R) => Rectangle.FromLTRB(R.Left, R.Top, R.Right, R.Bottom);
    }
}
