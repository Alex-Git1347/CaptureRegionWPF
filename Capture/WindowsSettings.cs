using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CaptureRegionWPF.Capture
{
    public class WindowsSettings : PropertyStore
    {
        public bool UseGdi
        {
            get => Get(false);
            set => Set(value);
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
