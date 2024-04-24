namespace CaptureRegionWPF.Interfaces
{
    public interface IVideoItem
    {
        string Name { get; }

        IImageProvider GetImageProvider(bool IncludeCursor);
    }
}
