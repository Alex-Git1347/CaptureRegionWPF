using CaptureRegionWPF.Interfaces;
using System;
using System.Drawing;

namespace CaptureRegionWPF.Capture
{
    public class FakeVideoSourcePicker : IVideoSourcePicker
    {
        FakeVideoSourcePicker() { }

        public static FakeVideoSourcePicker Instance { get; } = new FakeVideoSourcePicker();

        public IWindow SelectedWindow { get; set; }

        public IWindow PickWindow(Predicate<IWindow> Filter = null) => SelectedWindow;

        public IScreen SelectedScreen { get; set; }

        public IScreen PickScreen() => SelectedScreen;

        public Rectangle? PickRegion() => null;
    }
}
