using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;

namespace CloudTomato.CoreLogic.ViewModels
{
    public class PomodoraSessionViewModel : ViewModelBase
    {
        public PomodoraSessionViewModel()
        {
            StartSessionCommand = new RelayCommand(() => this.StartSession());
            StopSessionCommand = new RelayCommand(() => this.StopSession());
            ToggleSessionCommand = new RelayCommand(() => this.Toggle());
        }

        public ICommand StartSessionCommand { get; private set; }
        public ICommand StopSessionCommand { get; private set; }
        public ICommand ToggleSessionCommand { get; private set; }

        private int _TimeInMinutes = 25;
        public int TimeInMinutes
        {
            get
            {
                return _TimeInMinutes;
            }
            set
            {
                this.Set(ref _TimeInMinutes, value);
            }
        }


        private DateTime _StartTime;
        public DateTime StartTime
        {
            get
            {
                return _StartTime;
            }
            set
            {
                Set(ref _StartTime, value);
            }
        }


        private DateTime _EndTime;
        public DateTime EndTime
        {
            get
            {
                return _EndTime;
            }
            set
            {
                Set(ref _EndTime, value);
            }
        }


        private bool _IsRunning;
        public bool IsRunning
        {
            get
            {
                return _IsRunning;
            }
            set
            {
                Set(ref _IsRunning, value);
            }
        }

        public string ToggleButtonText
        {
            get
            {
                return IsRunning ? "Stop Session" : "Start Session";
            }
        }

        public string StatusText
        {
            get
            {
                return IsRunning ? "Started" : "Not Started";
            }
        }

        string GetTimerText(TimeSpan ts)
        {
            return $"{ts.Minutes:D2}:{ts.Seconds:D2}";
        }

        public string TimeDisplay
        {
            get
            {
                var minutes = new TimeSpan(0, TimeInMinutes, 0);

                if (!IsRunning)
                {
                    return GetTimerText(minutes);
                }

                var timeDiff = DateTime.Now - StartTime;
                var timeRemaining = minutes - timeDiff;

                return GetTimerText(timeRemaining);
            }
        }

        void NotifyTimeDisplayProperties()
        {
            this.RaisePropertyChanged(String.Empty);
        }

        public async Task StartSession()
        {
            StartTime = DateTime.Now;
            IsRunning = true;

            while (IsRunning)
            {
                RaisePropertyChanged(nameof(TimeDisplay));
                await Task.Delay(1000);
            }

            NotifyTimeDisplayProperties();
        }

        public void StopSession()
        {
            EndTime = DateTime.Now;
            IsRunning = false;
            NotifyTimeDisplayProperties();

            // Store the session
        }

        public void Toggle()
        {
            if (IsRunning)
            {
                StopSession();
            } else
            {
                StartSession();
            }
        }

    }
}
