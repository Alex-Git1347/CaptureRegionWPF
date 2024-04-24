namespace CaptureRegionWPF.Interfaces
{
    public interface IPreviewWindow
    {
        void Display(IBitmapFrame Frame);

        void Show();

        bool IsVisible { get; }
    }
}
