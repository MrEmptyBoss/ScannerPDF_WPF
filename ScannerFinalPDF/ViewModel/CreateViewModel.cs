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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using static System.Net.WebRequestMethods;

namespace ScannerFinalPDF.ViewModel
{
    class CreateViewModel : ViewModelBase
    {
        ApplicationContext db;
        private RS selectedRs;
        private Sroki selectedSroki;
        AlertPush alert;
        public DataGrid data_table_zayv_prot;
        public ObservableCollection<Maket> FilesP { get; set; } = new ObservableCollection<Maket>();
        public Maket SelectedFileP { get; set; }

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

        public CreateViewModel(DataGrid data_table_zayv)
        {
            db = new ApplicationContext();
            db.RS.Load();
            db.Sroki.Load();
            RsSp = db.RS.Local;
            sroki = db.Sroki.Local;
            data_table_zayv_prot = data_table_zayv;
            FilesP.Add(new Maket("xxx", 111, 121, 12, 1, 14, 0));
            FilesP.Add(new Maket("xx", 11, 12, 1, 1, 1, 0));
            FilesP.Add(new Maket("x", 1, 1, 93, 1, 14, 0));


        }

        public ICommand GetRowInfoBtn
        {
            get
            {
                return new RelayCommand(() => GetRowInfo());
            }
        }
        private void GetRowInfo()
        {
            if (SelectedFileP != null)
                MessageBox.Show($"кв: {SelectedFileP.Kvadr}\nИтого: {SelectedFileP.Count}");
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
              
                data_table_zayv_prot.Visibility = System.Windows.Visibility.Visible;

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
