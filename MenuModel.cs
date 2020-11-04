using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using AdaptTrial.Annotations;

namespace AdaptTrial
{
    public sealed class MenuModel : INotifyPropertyChanged
    {
        private ObservableCollection<string> _pageOptions = new ObservableCollection<string>();
        private string _outputText;
        private string _frameText;

        public ObservableCollection<string> PageOptions
        {
            get => _pageOptions;
            set
            {
                if (Equals(value, _pageOptions)) return;
                _pageOptions = value;
                OnPropertyChanged();
            }
        }

        public string OutputText
        {
            get => _outputText;
            set
            {
                if (value == _outputText) return;
                _outputText = value;
                OnPropertyChanged();
            }
        }

        public string FrameText
        {
            get => _frameText;
            set
            {
                if (value == _frameText) return;
                _frameText = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        private void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}