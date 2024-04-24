using CaptureRegionWPF.Providers;

namespace CaptureRegionWPF.ViewModels
{
    public class ServiceLocator
    {
        static ServiceLocator()
        {
            //ServiceProvider.LoadModule(new MainModule());
        }

        public RegionSelectorViewModel RegionSelectorViewModel => ServiceProvider.Get<RegionSelectorViewModel>();
    }
}
