﻿using GalaSoft.MvvmLight.Command;
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



            CurrentPage = Welcome;
        }

        public ICommand OpenControlPanel
        {
            get
            {
                return new RelayCommand(() => CurrentPage = ControlPanel);
            }
        }

        public ICommand OpenMainZayvok
        {
            get
            {
                return new RelayCommand(() => CurrentPage = MainZayvok);
            }
        }
        public ICommand OpenProfile
        {
            get
            {
                return new RelayCommand(() => CurrentPage = Profile);
            }
        }

        public ICommand OpenCreateZayv
        {
            get
            {
                return new RelayCommand(() => CurrentPage = CreateZayvok);
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
                return new RelayCommand(() => CurrentPage = Welcome);
            }
        }


    }
}
