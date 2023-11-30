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
    class ZayvkiViewModel: ViewModelBase
    {

        ApplicationContext db;
        AlertPush alert;
        public DataGrid data_table_zayv_prot;

        public ObservableCollection<Zayvka> ZayvkaP { get; set; }
        public ObservableCollection<Zayvka> Zayvkatemp = new ObservableCollection<Zayvka>();
        public Zayvka selectedZayvkaP { get; set; }
        public ZayvkiViewModel(DataGrid data_table_zayv)
        {
            db = new ApplicationContext();
            db.Zayvka.Load();
            ZayvkaP = db.Zayvka.Local;
            data_table_zayv_prot = data_table_zayv;

        }

        public ICommand OpenInfoZBtn
        {
            get
            {
                return new RelayCommand(() => OpenInfoZ());
            }
        }

        public ICommand OpenInfoAllZBtn
        {
            get
            {
                return new RelayCommand(() => OpenInfoAllZ());
            }
        }

        public ICommand OpenInfoVrabZBtn
        {
            get
            {
                return new RelayCommand(() => OpenInfoVrabZ());
            }
        }

        public ICommand OpenInfoNeVrabZBtn
        {
            get
            {
                return new RelayCommand(() => OpenInfoNeVrabZ());
            }
        }

        public ICommand OpenInfoZaverZBtn
        {
            get
            {
                return new RelayCommand(() => OpenInfoZaverZ());
            }
        }

        public ICommand OpenInfoOtmZBtn
        {
            get
            {
                return new RelayCommand(() => OpenInfoOtmZ());
            }
        }

        private void OpenInfoZ()
        {
            if (selectedZayvkaP != null)
                MessageBox.Show(Convert.ToString(selectedZayvkaP.Nshop));
        }

        private void OpenInfoAllZ()
        {
            db.Zayvka.Load();
            ZayvkaP = db.Zayvka.Local;
            
        }
        private void OpenInfoVrabZ()
        {
            Zayvkatemp.Clear();
            db.Zayvka.Load();
            var zayvkas = db.Zayvka.Local.Where(z => z.Status == "В работе");
            foreach(var zayvk in zayvkas)
            {
                Zayvkatemp.Add(zayvk);
            }
            ZayvkaP = Zayvkatemp;
          


        }
        private void OpenInfoNeVrabZ()
        {
            if (selectedZayvkaP != null)
                MessageBox.Show(Convert.ToString(selectedZayvkaP.Nshop));
        }
        private void OpenInfoZaverZ()
        {
            if (selectedZayvkaP != null)
                MessageBox.Show(Convert.ToString(selectedZayvkaP.Nshop));
        }
        private void OpenInfoOtmZ()
        {
            if (selectedZayvkaP != null)
                MessageBox.Show(Convert.ToString(selectedZayvkaP.Nshop));
        }
    }
}
