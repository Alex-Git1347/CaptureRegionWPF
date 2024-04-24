using CaptureRegionWPF.Capture;
using CaptureRegionWPF.Interfaces;
using CaptureRegionWPF.Providers;
using CaptureRegionWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Window = System.Windows.Window;

namespace CaptureRegionWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        IVideoSourceProvider _videoSourceKind;
        public MainWindow()
        {
            InitializeComponent();
        }

        public void ScreenShot(IVideoSourceProvider NewSourceProvider)
        {
            if (!NewSourceProvider.OnSelect())
            {
                return;
            }
            _videoSourceKind?.OnUnselect();

            _videoSourceKind = NewSourceProvider;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            VideoSourcePicker videoSource = new VideoSourcePicker();
            ServiceLocator locator = new ServiceLocator();
            WindowsPlatformServices patformServices = new WindowsPlatformServices();
            ScreenShot(new RegionSourceProvider(new RegionSelectorProvider(locator.RegionSelectorViewModel, patformServices), videoSource));
        }
    }
}
