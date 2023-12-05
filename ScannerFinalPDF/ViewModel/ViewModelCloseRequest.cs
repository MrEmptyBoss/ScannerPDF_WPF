using GalaSoft.MvvmLight.CommandWpf;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using static System.Net.Mime.MediaTypeNames;

namespace ScannerFinalPDF.ViewModel
{
    class ViewModelCloseRequest : ViewModelBase
    {
        private readonly ApplicationContext db;
        private RS selectedRs;
        private AlertPush alert;
        private ObservableCollection<RS> rsSp;
        private ObservableCollection<Zayvka> zayvkaP;
        private ICollectionView zayvkaPView;
        public DataGrid DataTableZayv { get; set; }

        public ObservableCollection<RS> RsSp
        {
            get => rsSp;
            set
            {
                rsSp = value;
                OnPropertyChanged(nameof(RsSp));
            }
        }
        public RS SelectedRS
        {
            get => selectedRs;
            set
            {
                selectedRs = value;
                OnPropertyChanged(nameof(SelectedRS));
                RsZayvkaChose();
            }
        }

        public ObservableCollection<Zayvka> ZayvkaP
        {
            get { return zayvkaP; }
            set
            {
                zayvkaP = value;
                OnPropertyChanged(nameof(ZayvkaP));

            }
        }
        public Zayvka SelectedZayvkaP { get; set; }
        public ViewModelCloseRequest(DataGrid tablezayvki)
        {
            db = new ApplicationContext();
            db.RS.Load();
            RsSp = db.RS.Local;
            DataTableZayv = tablezayvki;
            db.Zayvka.Load();
            ZayvkaP = new ObservableCollection<Zayvka>(db.Zayvka.Local.Where(z => z.Status == "В работе"));
            zayvkaPView = CollectionViewSource.GetDefaultView(ZayvkaP);

        }

        private void UpdateZayvkaCollection(IEnumerable<Zayvka> zayvkaQuery)
        {
            ZayvkaP.Clear();
            foreach (var zayvk in zayvkaQuery)
            {
                ZayvkaP.Add(zayvk);
            }

            // Обновляем ICollectionView
            zayvkaPView.Refresh();

            // Вызываем событие PropertyChanged
            OnPropertyChanged(nameof(ZayvkaP));
        }

        private void RsZayvkaChose()
        {
            db.Zayvka.Load();
            var zayvkas = db.Zayvka.Local.Where(z => z.IdRS == selectedRs.id && z.Status == "В работе");
            UpdateZayvkaCollection(zayvkas);
        }

        public ICommand ZakrZBtn => new RelayCommand(ZakrZ);
        private void ZakrZ()
        {
            if (SelectedZayvkaP != null)
            {
                SelectedZayvkaP.Status = "Завершено";
                int track = Math.Abs(SelectedZayvkaP.Namerequest.GetHashCode());
                SelectedZayvkaP.Numbertruck = track;
                SelectedZayvkaP.Dateclose = DateTime.Now;
                db.SaveChanges();
                MessageBox.Show($"Заявка {SelectedZayvkaP.Namerequest} закрыта");
            }

        }
    }
}
