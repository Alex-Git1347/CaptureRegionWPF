using System.Drawing;

namespace CaptureRegionWPF.Interfaces
{
    public interface IScreen
    {
        Rectangle Rectangle { get; }

        string DeviceName { get; }
    }
}
