using CaptureRegionWPF.Interfaces;
using System.Drawing;

namespace CaptureRegionWPF.Providers
{
    public class VideoSourcePicker : IVideoSourcePicker
    {
        public Rectangle? PickRegion()
        {
            return RegionPickerWindow.PickRegion();
        }
    }
}
