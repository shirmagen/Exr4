using System.ComponentModel.Composition;
using Caliburn.Micro;

namespace Exr4.ViewModels
{
    [Export(typeof(MainWindowViewModel))]
    public class MainWindowViewModel : BaseWindowViewModel, IHandle<string>
    {
        private FirstWindowViewModel _firstWindow;
        private SecondWindowViewModel _secondWindow;
        private ThirdWindowViewModel _thirdWindow;
        private string _labelText;

        public string LabelText
        {
            get => _labelText;
            set
            {
                _labelText = value;
                NotifyOfPropertyChange(() => LabelText);
            }
        }

        [ImportingConstructor]
        public MainWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator) : base(windowManager, eventAggregator)
        {
            _firstWindow = new FirstWindowViewModel(_windowManager, _eventAggregator);
            _secondWindow = new SecondWindowViewModel(_windowManager, _eventAggregator);
            _thirdWindow = new ThirdWindowViewModel(_windowManager, _eventAggregator);
            Message = "שלום";
        }

        public void OpenFirstWindow()
        {
            ActivateItem(_firstWindow);
        }

        public void OpenSecondWindow()
        {
            ActivateItem(_secondWindow);
        }

        public void OpenThirdWindow()
        {
            ActivateItem(_thirdWindow);
        }

        public void Handle(string message)
        {
            LabelText = message;
            DeactivateItem(ActiveItem, true);
        }
    }
}