using System;
using Caliburn.Micro;

namespace Exr4.ViewModels
{
    public abstract class BaseWindowViewModel : Conductor<Screen>
    {
        protected IWindowManager _windowManager;
        protected IEventAggregator _eventAggregator;
        protected string _message;

        public string Message
        {
            get => _message;
            set
            {
                _message = value;
                MessageChanged(Message);
                NotifyOfPropertyChange(() => Message);
            }
        }

        protected BaseWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator)
        {
            _windowManager = windowManager;
            _eventAggregator = eventAggregator;
            _eventAggregator.Subscribe(this);
        }

        public void MessageChanged(string message)
        {
            _eventAggregator.PublishOnUIThread(message);
        }
    }
}