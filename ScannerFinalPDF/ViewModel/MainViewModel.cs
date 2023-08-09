using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScannerFinalPDF.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        private Page Welcome;
        private Page Profile;
        private Page Settings;
        private Page ControlPanel;

        private Page _currentPage;

       public Page CurrentPage
        {
            get => _currentPage;
            set => Set(ref _currentPage, value);
        }


        public MainViewModel()
        {
            Welcome = new View.Pages.Welcome();
            Profile = new View.Pages.Profile();
            Settings = new View.Pages.Settings();
            ControlPanel = new View.Pages.ControlPanel();

            CurrentPage = Welcome;
        }

        public ICommand OpenControlPanel
        {
            get
            {
                return new RelayCommand(() => CurrentPage = ControlPanel);
            }
        }

        public ICommand OpenWelcome
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Welcome);
            }
        }


    }
}
