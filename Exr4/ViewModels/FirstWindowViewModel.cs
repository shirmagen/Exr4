using System;
using System.Windows.Threading;
using Caliburn.Micro;

namespace Exr4.ViewModels
{
    public class FirstWindowViewModel : BaseWindowViewModel
    {
        private int _clicksCounter;
        private int _numOfRequiredClicks;
        private int _roundNumber;

        public int NumOfRequiredClicks
        {
            get => _numOfRequiredClicks;
            set
            {
                _numOfRequiredClicks = value;
                NotifyOfPropertyChange(() => NumOfRequiredClicks);
            }
        }

        public FirstWindowViewModel(IWindowManager windowManager, IEventAggregator eventAggregator) : base(windowManager, eventAggregator)
        {
            _roundNumber = 0;
        }

        private void SelfKiller()
        {
            var timer = new DispatcherTimer {Interval = TimeSpan.FromSeconds(7.5)};
            timer.Tick += TimerTick;
            timer.Start();
        }

        private void TimerTick(object sender, EventArgs e)
        {
            var timer = (DispatcherTimer)sender;
            timer.Stop();
            timer.Tick -= TimerTick;
            HandleFail();
        }

        private void HandleFail()
        {
            Message = "על הפנים";
            _clicksCounter = 0;
        }

        public void ButtonClicked()
        {
            _clicksCounter++;

            if (_clicksCounter == _numOfRequiredClicks)
            {
                _roundNumber++;
                
                if (_roundNumber == 3)
                {
                    Message = "מזל טוב!";
                    _roundNumber = 0;
                }
                else
                {
                    Message = "שלום";
                }
            }
        }

        protected override void OnActivate()
        {
            _clicksCounter = 0;
            NumOfRequiredClicks = new Random().Next(1, 5);
            SelfKiller();
            base.OnActivate();
        }
    }
}