using System;
using System.Drawing;

namespace CaptureRegionWPF.Interfaces
{
    public interface IRegionProvider
    {
        bool SelectorVisible { get; set; }

        Rectangle SelectedRegion { get; set; }

        IVideoItem VideoSource { get; }

        IntPtr Handle { get; }
    }
}
