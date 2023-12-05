using GalaSoft.MvvmLight.Command;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace ScannerFinalPDF.ViewModel
{
    class MainViewModel : ViewModelBase
    {
        MainWindow main;
        private Page Welcome;
        private Page Profile;
        private Page Settings;
        private Page ControlPanel;
        private Page CreateZayvok;
        private Page MainZayvok;
        private Page CloseRequest;



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
            CreateZayvok = new View.Pages.CreateZayvka();
            MainZayvok = new View.Pages.MainZayvki();
            CloseRequest = new View.Pages.CloseRequest();



            CurrentPage = Welcome;
        }

        public ICommand OpenControlPanel
        {
            get
            {
                return new RelayCommand(() => ChangePage(ControlPanel));
            }
        }

        public ICommand OpenMainZayvok
        {
            get
            {
                return new RelayCommand(() => ChangePage(MainZayvok));
            }
        }

        public ICommand OpenZakrZayvok
        {
            get
            {
                return new RelayCommand(() => ChangePage(CloseRequest));
            }
        }
        public ICommand OpenProfile
        {
            get
            {
                return new RelayCommand(() => ChangePage(Profile));
            }
        }

        public ICommand OpenCreateZayv
        {
            get
            {
                return new RelayCommand(() => ChangePage(CreateZayvok));
            }
        }

        public ICommand ToAtuthB
        {
            get
            {
                return new RelayCommand(() => ToAtuth());
            }
        }

        private void ToAtuth()
        {
            main = new MainWindow();
            main.Show();
            foreach (Window item in Application.Current.Windows)
            {
                if (item.DataContext == this) item.Close();
            }
        }

        public ICommand OpenWelcome
        {
            get
            {
                return new RelayCommand(() => ChangePage(Welcome));
            }
        }

        private void ChangePage(Page newPage)
        {
            CurrentPage = newPage;

            // Вызываем метод обновления модели при изменении страницы
            DataWorker.UpdateModel();
        }


    }
}
