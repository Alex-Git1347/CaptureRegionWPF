using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
namespace CaptureRegionWPF.Interfaces
{
    public interface IVideoSourcePicker
    {
        //IWindow PickWindow(Predicate<IWindow> Filter = null);

        //IScreen PickScreen();

        Rectangle? PickRegion();
    }
}
