using Caliburn.Micro;

namespace Exr4.ViewModels
{
    public abstract class BaseWindowViewModel : Conductor<Screen>, IHandle<string>
    {
        protected IWindowManager _windowManager;
        protected IEventAggregator _eventAggregator;
        private string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                NotifyOfPropertyChange(() => Message);
                MessageChanged(Message);
            }
        }

        protected BaseWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            Message = "שלום";
        }

        public void MessageChanged(string message)
        {
            _eventAggregator.PublishOnUIThread(message);
        }

        public void Handle(string message)
        {
            Message = message;
        }
    }
}