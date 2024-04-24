using System;

namespace CaptureRegionWPF.Interfaces
{
    interface ITargetDeviceContext : IDisposable
    {
        IntPtr GetDC();

        IBitmapFrame DummyFrame { get; }

        IEditableFrame GetEditableFrame();
    }
}
