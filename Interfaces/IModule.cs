using System;

namespace CaptureRegionWPF.Interfaces
{
    public interface IModule : IDisposable
    {
        void OnLoad(IBinder Binder);
    }
}
