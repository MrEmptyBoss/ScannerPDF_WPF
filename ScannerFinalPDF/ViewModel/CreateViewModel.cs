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
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;

namespace ScannerFinalPDF.ViewModel
{
    class CreateViewModel : ViewModelBase
    {
        private readonly ApplicationContext db;
        private RS selectedRs;
        private Sroki selectedSroki;
        private AlertPush alert;

        public DataGrid DataTableZayvProt { get; set; }
        public TextBlock RedText { get; set; }
        public TextBox NshopTextBlock { get; set; }
        public RichTextBox CommentZayvki { get; set; }
        public List<Maket> scanner_Maket;

        public ObservableCollection<Maket> FilesP { get; set; } = new ObservableCollection<Maket>();
        public Maket SelectedFileP { get; set; }
        public ObservableCollection<Sroki> Sroki { get; set; }
        private ObservableCollection<RS> rsSp;
        private ObservableCollection<Zayvka> zayvkii;
        public ObservableCollection<RS> RsSp
        {
            get => rsSp;
            set
            {
                rsSp = value;
                OnPropertyChanged(nameof(RsSp));
            }
        }

        public ObservableCollection<Zayvka> Zayvkii
        {
            get => zayvkii;
            set
            {
                zayvkii = value;
                OnPropertyChanged(nameof(Zayvkii));
            }
        }


        public CreateViewModel(DataGrid dataTableZayv, TextBlock redText, TextBox nshopTextBlock, RichTextBox commentZayvki)
        {

            db = new ApplicationContext();
            db.RS.Load();
            db.Sroki.Load();
            RsSp = db.RS.Local;
            Sroki = db.Sroki.Local;
            DataTableZayvProt = dataTableZayv;
            RedText = redText;
            NshopTextBlock = nshopTextBlock;
            CommentZayvki = commentZayvki;
        }

        public ICommand GetFilesBtn => new RelayCommand(() => GetFiles());

        private void GetFiles()
        {
            if (DataTableZayvProt.ItemsSource != null)
            {
                db.Zayvka.Load();
                Zayvkii = db.Zayvka.Local;
                int tempid = Zayvkii.Count;
                Zayvka zayvka = new Zayvka
                {
                    id = tempid + 1,
                    Idsotr = 1,
                    IdRS = selectedRs.id,
                    Namerequest = $"SC-{tempid + 1}",
                    Idsroki = selectedSroki.id,
                    Nshop = Convert.ToInt32(NshopTextBlock.Text),
                    Datepriem = DateTime.Now,
                    Dateplanov = DateTime.Now.AddDays(selectedSroki.Coldn),
                    Status = "Новая заявка",
                    Commentz = new TextRange(CommentZayvki.Document.ContentStart, CommentZayvki.Document.ContentEnd).Text
                };
                db.Zayvka.Add(zayvka);
                db.SaveChanges();

                foreach (var maket in scanner_Maket)
                {
                    maket.Kvadr = Convert.ToDouble((Convert.ToDouble(maket.Length) * Convert.ToDouble(maket.Width) * Convert.ToDouble(maket.Count)) / 1000000.0);
                    maket.Idrequest = zayvka.id;
                    db.Maket.Add(maket);
                    db.SaveChanges();
                }

                alert = new AlertPush("Заявка отправлена!");
                alert.Show();


            }
        }

        public RS SelectedRS
        {
            get => selectedRs;
            set
            {
                selectedRs = value;
                OnPropertyChanged(nameof(SelectedRS));
            }
        }

        public Sroki SelectedSroki
        {
            get => selectedSroki;
            set
            {
                selectedSroki = value;
                OnPropertyChanged(nameof(SelectedSroki));
            }
        }

        public ICommand CreateZayvBtn => new RelayCommand(() => CreateZayv());

        private void CreateZayv()
        {
            string folderPath = OpenDialog();
            if (folderPath != null)
            {
                if (scanner_Maket != null)
                {
                    scanner_Maket.Clear();
                }
                alert = new AlertPush("Идет сканирование, пожалуйста подождите");
                alert.Show();
                Scanner_Filles scanner_Filles = new Scanner_Filles();
                scanner_Maket = scanner_Filles.InfoFiles(folderPath);
                DataTableZayvProt.ItemsSource = scanner_Maket;
                DataTableZayvProt.Visibility = Visibility.Visible;
                RedText.Opacity = 1;
            }
            else
            {
                alert = new AlertPush("Вы не выбрали папку!");
                alert.Show();
            }
        }

        public string OpenDialog()  // Открытие проводника
        {
            string folderPath = null;

            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                RestoreDirectory = false,
                ValidateNames = false,
                CheckFileExists = false,
                CheckPathExists = true,
                FileName = "Folder Selection."
            };

            Nullable<bool> result = openFileDialog.ShowDialog();
            if (result == true)
            {
                folderPath = Path.GetDirectoryName(openFileDialog.FileName);
            }
            return folderPath;
        }
    }
}
