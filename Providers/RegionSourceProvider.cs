using CaptureRegionWPF.Interfaces;
using System;

namespace CaptureRegionWPF.Providers
{
    public class RegionSourceProvider : IVideoSourceProvider
    {
        readonly IRegionProvider _regionProvider;
        readonly IVideoSourcePicker _videoSourcePicker;

        public RegionSourceProvider(
            IRegionProvider RegionProvider,
            IVideoSourcePicker VideoSourcePicker) 
        {
            _videoSourcePicker = VideoSourcePicker;
            _regionProvider = RegionProvider;

        }

        //public override IVideoItem Source { get; }

        //public override string Name => Loc.Region;

        //public override string Description { get; } = "Record region selected using Region Selector.";

        //public override string Icon { get; }

        // Prevents opening multiple region pickers at the same time
        bool _picking;

        public string Name => throw new NotImplementedException();

        public string Description => throw new NotImplementedException();

        public string Icon => throw new NotImplementedException();

        public IVideoItem Source => throw new NotImplementedException();

        public bool SupportsStepsMode => throw new NotImplementedException();

        public bool OnSelect()
        {
            if (_picking)
                return false;

            _picking = true;

            try
            {
                var wasVisible = _regionProvider.SelectorVisible;

                _regionProvider.SelectorVisible = false;

                var region = _videoSourcePicker.PickRegion();

                if (region == null)
                {
                    // Show again if was already visible
                    _regionProvider.SelectorVisible = true;

                    return false;
                }

                _regionProvider.SelectedRegion = region.Value;

                _regionProvider.SelectorVisible = true;
            }
            finally
            {
                _picking = false;
            }

            return true;
        }

        public void OnUnselect()
        {
            _regionProvider.SelectorVisible = false;
        }

        public IBitmapImage Capture(bool IncludeCursor)
        {
            throw new NotImplementedException();
        }

        public string Serialize()
        {
            throw new NotImplementedException();
        }

        public bool Deserialize(string Serialized)
        {
            throw new NotImplementedException();
        }

        public bool ParseCli(string Arg)
        {
            throw new NotImplementedException();
        }

        //public override string Serialize()
        //{
        //    var rect = _regionProvider.SelectedRegion;
        //    return rect.ConvertToString();
        //}

        //public override bool Deserialize(string Serialized)
        //{
        //    if (!(Serialized.ConvertToRectangle() is Rectangle rect))
        //        return false;

        //    _regionProvider.SelectedRegion = rect;

        //    _regionProvider.SelectorVisible = true;

        //    return true;
        //}

        //public override bool ParseCli(string Arg)
        //{
        //    if (!(Arg.ConvertToRectangle() is Rectangle rect))
        //        return false;

        //    _regionProvider.SelectedRegion = rect.Even();

        //    return true;
        //}

        //public override IBitmapImage Capture(bool IncludeCursor)
        //{
        //    return ScreenShot.Capture(_regionProvider.SelectedRegion, IncludeCursor);
        //}
    }
}
