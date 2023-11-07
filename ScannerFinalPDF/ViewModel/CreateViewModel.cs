using GalaSoft.MvvmLight.CommandWpf;
using Microsoft.Win32;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.Model.Scanner;
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
        public TextBlock Red_Text;
        public List<Maket> scanner_Maket;
        public TextBox nshop_TextBlock;

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

        public CreateViewModel(DataGrid data_table_zayv, TextBlock red_text, TextBox Nshop_TextBlock)
        {
            db = new ApplicationContext();
            db.RS.Load();
            db.Sroki.Load();
            RsSp = db.RS.Local;
            sroki = db.Sroki.Local;
            data_table_zayv_prot = data_table_zayv;
            Red_Text = red_text;
            nshop_TextBlock = Nshop_TextBlock;

        }

        public ICommand GetFillesBtn
        {
            get
            {
                return new RelayCommand(() => GetFilles());
            }
        }
        private void GetFilles()
        {
           if (data_table_zayv_prot.ItemsSource != null)
            {
                Zayvka zayvka = new Zayvka();
                zayvka.Idsotr = 1;
                zayvka.IdRS = selectedRs.id;
                zayvka.Namerequest = $"SC-{zayvka.id}";
                zayvka.Idsroki = selectedSroki.id;
                zayvka.Nshop = Convert.ToInt32(nshop_TextBlock.Text);
                zayvka.Datepriem = DateTime.Now;
                DateTime datenow = DateTime.Now;
                zayvka.Dateplanov = datenow.AddDays(selectedSroki.Coldn);
                db.Zayvka.Add(zayvka);
                db.SaveChanges();
                for (int i = 0; i < scanner_Maket.Count; i++)
                {
                    scanner_Maket[i].Kvadr = Convert.ToDouble((Convert.ToDouble(scanner_Maket[i].Length) * Convert.ToDouble(scanner_Maket[i].Width) * Convert.ToDouble(scanner_Maket[i].Count))/1000000.0);
                    scanner_Maket[i].Idrequest = zayvka.id;
                    db.Maket.Add(scanner_Maket[i]);
                    db.SaveChanges();
                }
            }
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
                if(scanner_Maket != null)
                {
                    scanner_Maket.Clear();
                }
                alert = new AlertPush("Идет сканирование, пожалуйста подождите");
                alert.Show();
                Scanner_Filles scanner_Filles = new Scanner_Filles();
                scanner_Maket = scanner_Filles.InfoFiles(pt);
                data_table_zayv_prot.ItemsSource = scanner_Maket;
                data_table_zayv_prot.Visibility = Visibility.Visible;
                Red_Text.Opacity = 1;

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
