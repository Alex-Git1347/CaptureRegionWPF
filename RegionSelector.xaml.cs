using CaptureRegionWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace CaptureRegionWPF
{
    /// <summary>
    /// Interaction logic for RegionSelector.xaml
    /// </summary>
    public partial class RegionSelector : Window
    {
        readonly RegionSelectorViewModel _viewModel;
        public RegionSelector(RegionSelectorViewModel ViewModel)
        {
            _viewModel = ViewModel;

            InitializeComponent();
            Closing += (S, E) => E.Cancel = true;

            InkCanvas.DefaultDrawingAttributes.FitToCurve = true;
        }

        protected override void OnRenderSizeChanged(SizeChangedInfo SizeInfo)
        {
            InkCanvas.Strokes.Clear();

            base.OnRenderSizeChanged(SizeInfo);
        }

        public IntPtr Handle => new WindowInteropHelper(this).Handle;

        void UIElement_OnPreviewMouseLeftButtonDown(object Sender, MouseButtonEventArgs E)
        {
            DragMove();
        }

        void Thumb_OnDragDelta(object Sender, DragDeltaEventArgs E)
        {
            void DoTop() => _viewModel.ResizeFromTop(E.VerticalChange);

            void DoLeft() => _viewModel.ResizeFromLeft(E.HorizontalChange);

            void DoBottom()
            {
                var height = Region.Height + E.VerticalChange;

                if (height > 0)
                    Region.Height = height;
            }

            void DoRight()
            {
                var width = Region.Width + E.HorizontalChange;

                if (width > 0)
                    Region.Width = width;
            }

            if (Sender is FrameworkElement element)
            {
                switch (element.Tag)
                {
                    case "Bottom":
                        DoBottom();
                        break;

                    case "Left":
                        DoLeft();
                        break;

                    case "Right":
                        DoRight();
                        break;

                    case "TopLeft":
                        DoTop();
                        DoLeft();
                        break;

                    case "TopRight":
                        DoTop();
                        DoRight();
                        break;

                    case "BottomLeft":
                        DoBottom();
                        DoLeft();
                        break;

                    case "BottomRight":
                        DoBottom();
                        DoRight();
                        break;
                }
            }
        }

    }
}
