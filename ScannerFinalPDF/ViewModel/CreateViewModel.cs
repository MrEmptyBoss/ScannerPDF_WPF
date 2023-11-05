using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ScannerFinalPDF.ViewModel
{
    class CreateViewModel : ViewModelBase
    {
        ApplicationContext db;
        private RS selectedRs;
        private Sroki selectedSroki;
        AlertPush alert;

        private ObservableCollection<RS> selectedRSs;
        public ObservableCollection<Sroki> sroki { get; set; }

        public ObservableCollection<RS> RsSp
        {
            get => selectedRSs;
            set
            {
                selectedRSs = value;
                OnPropertyChanged("Rs");
            }
        }

        public CreateViewModel()
        {
            db = new ApplicationContext();
            db.RS.Load();
            db.Sroki.Load();
            RsSp = db.RS.Local;
            sroki = db.Sroki.Local;

        }

        public RS SelectedRS
        {
            get { return selectedRs; }
            set
            {
                selectedRs = value;
                OnPropertyChanged("SelectedRS");
            }
        }
        public Sroki SelectedSroki
        {
            get { return selectedSroki; }
            set
            {
                selectedSroki = value;
                OnPropertyChanged("SelectedSroki");
            }
        }

        public ICommand CreateZayvBtn
        {
            get
            {
                return new RelayCommand(() => CreateZayv());
            }
        }

        private void CreateZayv()
        {

            string pt = openDialog();
            if (pt != null)
            {


            }
            else
            {
                alert = new AlertPush("Вы не выбрали папку!");
                alert.Show();
            }
        }

        public string openDialog()  // Открытие проводника
        {
                 string fp = null;

                OpenFileDialog openFileDialog = new OpenFileDialog();

                openFileDialog.RestoreDirectory = false;
                openFileDialog.ValidateNames = false;
                openFileDialog.CheckFileExists = false;
                openFileDialog.CheckPathExists = true;
                openFileDialog.FileName = "Folder Selection.";
                Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                string folderPath = Path.GetDirectoryName(openFileDialog.FileName);
                fp = folderPath;
            }
                return fp;
        }
    }
}
