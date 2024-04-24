using CaptureRegionWPF.Capture;
using CaptureRegionWPF.Interfaces;
using CaptureRegionWPF.Providers;
using CaptureRegionWPF.ViewModels;
using Prism.Ioc;
using Prism.Unity;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Window = System.Windows.Window;

namespace CaptureRegionWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : PrismApplication
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            base.InitializeModules();
            containerRegistry.Register<IVideoSourceProvider, RegionSourceProvider>();
            containerRegistry.Register<IVideoSourcePicker, VideoSourcePicker>();
            containerRegistry.Register<IRegionProvider, RegionSelectorProvider>();
            containerRegistry.Register<IPlatformServices, WindowsPlatformServices>();

            containerRegistry.RegisterSingleton<RegionSelectorViewModel>();
            //Binder.BindSingleton<RegionSelectorViewModel>();
            //containerRegistry.Register<IRegionProvider, RegionSelectorProvider>();
            //Binder.Bind<IRegionProvider, RegionSelectorProvider>();
            //Bind<IPlatformServices, WindowsPlatformServices>();
            //containerRegistry.Register<IVideoSourcePicker, FakeVideoSourcePicker>();
            //Binder.Bind<IVideoSourcePicker>(() => FakeVideoSourcePicker.Instance);
            //Bind<IRegionProvider>(() => FakeRegionProvider.Instance);
        }

        protected override Window CreateShell()
        {
            return Application.Current.MainWindow;
        }
    }
}
