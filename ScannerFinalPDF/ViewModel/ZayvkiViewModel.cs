using GalaSoft.MvvmLight.CommandWpf;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;

namespace ScannerFinalPDF.ViewModel
{
    class ZayvkiViewModel : ViewModelBase
    {
        private readonly ApplicationContext db;
        private AlertPush alert;

        private ObservableCollection<Zayvka> zayvkaP;

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

        private ICollectionView zayvkaPView;

        public ZayvkiViewModel()
        {
            db = new ApplicationContext();
            db.Zayvka.Load();
            ZayvkaP = new ObservableCollection<Zayvka>(db.Zayvka.Local);
            zayvkaPView = CollectionViewSource.GetDefaultView(ZayvkaP);
            CreateViewModel.ZayvkaUpdated += ZayvkiViewModel_ZayvkaUpdated;
        }

        private void ZayvkiViewModel_ZayvkaUpdated(object sender, EventArgs e)
        {
            ZayvkaP = (sender as CreateViewModel)?.Zayvkii;
        }

        #region Commands

        public ICommand OpenInfoZBtn => new RelayCommand(OpenInfoZ);
        public ICommand OpenInfoAllZBtn => new RelayCommand(OpenInfoAllZ);
        public ICommand OpenInfoVrabZBtn => new RelayCommand(OpenInfoVrabZ);
        public ICommand OpenInfoNeVrabZBtn => new RelayCommand(OpenInfoNeVrabZ);
        public ICommand OpenInfoZaverZBtn => new RelayCommand(OpenInfoZaverZ);
        public ICommand OpenInfoOtmZBtn => new RelayCommand(OpenInfoOtmZ);

        #endregion

        private void OpenInfoZ()
        {
            if (SelectedZayvkaP != null)
            {
                //SelectedZayvkaP.Status = "Отменено";
                //db.SaveChanges();
                MessageBox.Show("Статус изменен!");
            }
                
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

        private void OpenInfoAllZ()
        {
            db.Zayvka.Load();
            UpdateZayvkaCollection(db.Zayvka.Local);
        }

        private void OpenInfoVrabZ()
        {
            var zayvkas = db.Zayvka.Local.Where(z => z.Status == "В работе");
            UpdateZayvkaCollection(zayvkas);
        }

        private void OpenInfoNeVrabZ()
        {
            var zayvkas = db.Zayvka.Local.Where(z => z.Status == "Не в работе");
            UpdateZayvkaCollection(zayvkas);
        }

        private void OpenInfoZaverZ()
        {
            var zayvkas = db.Zayvka.Local.Where(z => z.Status == "Завершено");
            UpdateZayvkaCollection(zayvkas);
        }

        private void OpenInfoOtmZ()
        {
            var zayvkas = db.Zayvka.Local.Where(z => z.Status == "Отменено");
            UpdateZayvkaCollection(zayvkas);
        }
    }
}