using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace AmisDeOutdoorApp.ViewModels
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private object currentView;

        public object CurrentView
        {
            get { return currentView; }
            set
            {
                currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowCalendarViewCommand { get; }
        public ICommand ShowWeatherViewCommand { get; }
        public ICommand ShowEquipmentViewCommand { get; }

        public MainViewModel()
        {
            ShowCalendarViewCommand = new RelayCommand(ShowCalendarView);
            ShowWeatherViewCommand = new RelayCommand(ShowWeatherView);
            ShowEquipmentViewCommand = new RelayCommand(ShowEquipmentView);

            // Default view
            ShowWeatherView();
        }

        private void ShowCalendarView()
        {
            CurrentView = new CalendarViewModel();
        }

        private void ShowWeatherView()
        {
            CurrentView = new WeatherViewModel();
        }

        private void ShowEquipmentView()
        {
            CurrentView = new EquipmentViewModel();
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }

    public class RelayCommand : ICommand
    {
        private readonly Action execute;
        private readonly Func<bool> canExecute;

        public RelayCommand(Action execute, Func<bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return canExecute == null || canExecute();
        }

        public void Execute(object parameter)
        {
            execute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }
    }
}
