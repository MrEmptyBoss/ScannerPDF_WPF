using GalaSoft.MvvmLight;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View;
using ScannerFinalPDF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ScannerFinalPDF.Model.ViewModel
{
    public class DataManagerVM : INotifyPropertyChanged
    {
        public List<Zayvka> zayvkas = DataWorker.GetAllZayvka();
        public List<Sroki> srokis = DataWorker.GetAllsroki();
        public List<RS> rs = DataWorker.GetAllrs();
        public List<User> users = DataWorker.GetAlluser();
        public List<Position> positions = DataWorker.GetAllpos();


        #region Данные
        public string SrokiName { get; set; }
        public int SrokiColdn { get; set; }
        #endregion


        public List<Zayvka> AllZayvki
        {
            get { return zayvkas; }
            set
            {
                zayvkas = value;
                OnPropertyChanged(nameof(zayvkas));
            }
        }

        public List<Sroki> AllSroki
        {
            get { return srokis; }
            set
            {
                srokis = value;
                OnPropertyChanged(nameof(srokis));
            }
        }

        public List<User> AllUsers
        {
            get { return users; }
            set
            {
                users = value;
                OnPropertyChanged(nameof(users));
            }
        }

        public List<Position> AllPos
        {
            get { return positions; }
            set
            {
                positions = value;
                OnPropertyChanged(nameof(positions));
            }
        }

        public List<RS> AllRs
        {
            get { return rs; }
            set
            {
                rs = value;
                OnPropertyChanged(nameof(rs));
            }
        }
        private RelayCommand openAddSrokiWnd;
        public RelayCommand OpenAddSrokiWnd
        {
            get
            {
                return openAddSrokiWnd ?? new RelayCommand(obj =>
                {
                    OpenAddSrokWindow();
                });
            }
        }

        private void OpenAddSrokWindow()
        {
            AddNewSrokiWindow newSrokiWindow = new AddNewSrokiWindow();
            SetCenterPositionAndOpen(newSrokiWindow);
        }

        public RelayCommand addNewSroki;

        public RelayCommand AddNewSroki
        {
            get
            {
                return addNewSroki ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resStr = "";
                    if (SrokiName == null || SrokiName.Replace(" ", "").Length == 0)
                    {

                    }
                    else
                    {
                        resStr = DataWorker.CreateSroki(SrokiName, SrokiColdn);
                        UpdateAllDataView();
                        wnd.Close();
                    }
                });
            }
        }

        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }

        #region updtae views
        private void UpdateAllDataView()
        {
            UpdateAllSrokiView();
            UpdateAllPositionsView();
            UpdateAllUsersView();
            UpdateAllRsView();
            UpdateAllZayvkiView();

        }
        private void UpdateAllSrokiView()
        {
            AllSroki = DataWorker.GetAllsroki();
            MainHome.AllSrokiView.ItemsSource = null;
            MainHome.AllSrokiView.Items.Clear();
            MainHome.AllSrokiView.ItemsSource = AllSroki;
            MainHome.AllSrokiView.Items.Refresh();
        }

        private void UpdateAllPositionsView()
        {
            AllPos = DataWorker.GetAllpos();
            MainHome.AllPositionsView.ItemsSource = null;
            MainHome.AllPositionsView.Items.Clear();
            MainHome.AllPositionsView.ItemsSource = AllPos;
            MainHome.AllPositionsView.Items.Refresh();
        }

        private void UpdateAllUsersView()
        {
            AllUsers = DataWorker.GetAlluser();
            MainHome.AllUsersView.ItemsSource = null;
            MainHome.AllUsersView.Items.Clear();
            MainHome.AllUsersView.ItemsSource = AllUsers;
            MainHome.AllUsersView.Items.Refresh();
        }

        private void UpdateAllZayvkiView()
        {
            AllZayvki = DataWorker.GetAllZayvka();
            MainHome.AllZayvkiView.ItemsSource = null;
            MainHome.AllZayvkiView.Items.Clear();
            MainHome.AllZayvkiView.ItemsSource = AllZayvki;
            MainHome.AllZayvkiView.Items.Refresh();
        }
        private void UpdateAllRsView()
        {
            AllRs = DataWorker.GetAllrs();
            MainHome.AllRsView.ItemsSource = null;
            MainHome.AllRsView.Items.Clear();
            MainHome.AllRsView.ItemsSource = AllRs;
            MainHome.AllRsView.Items.Refresh();
        }
        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }

}
