using System;

namespace CaptureRegionWPF.Interfaces
{
    public interface IMessageProvider
    {
        void ShowError(string Message, string Header = null);

        bool ShowYesNo(string Message, string Title);

        void ShowException(Exception Exception, string Message, bool Blocking = false);
    }
}
