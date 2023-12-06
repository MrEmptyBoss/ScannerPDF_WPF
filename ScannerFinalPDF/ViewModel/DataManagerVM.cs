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
using System.Windows.Controls;

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
        // свойства срока
        public string SrokiName { get; set; }
        public int SrokiColdn { get; set; }
        // свойства РЦ
        public int NameRS { get; set; }
        public string Email { get; set; }
        // свойства должности
        public string PosName { get; set; }
        //  свойства пользователя
        public string LoginUser { get; set; }
        public string PassUser { get; set; }
        public string FioUser { get; set; }
        public DateTime DateRozhUser { get; set; }
        public Position PositionUser { get; set; }
        // свойства для выделенных элементов 
        public TabItem SelectedTabItem { get; set; }
        public User SelectedUser { get; set; }
        public Position SelectedPos { get; set; }
        public Sroki SelectedSrok { get; set; }
        public RS SelectedRs { get; set; }
        public Zayvka SelectedZayvka { get; set; }

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

        #region Сроки
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
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }
        #endregion

        #region РЦ
        private RelayCommand openAddRsWnd;
        public RelayCommand OpenAddRsWnd
        {
            get
            {
                return openAddRsWnd ?? new RelayCommand(obj =>
                {
                    OpenAddRsWindow();
                });
            }
        }

        private void OpenAddRsWindow()
        {
            AddNewRsWindow newRsWindow = new AddNewRsWindow();
            SetCenterPositionAndOpen(newRsWindow);
        }

        public RelayCommand addNewRs;

        public RelayCommand AddNewRs
        {
            get
            {
                return addNewRs ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resStr = "";
                    if (Email == null || Email.Replace(" ", "").Length == 0)
                    {

                    }
                    else
                    {
                        resStr = DataWorker.CreateRs(NameRS, Email);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }
        #endregion

        #region Должность
        private RelayCommand openAddPosWnd;
        public RelayCommand OpenAddPosWnd
        {
            get
            {
                return openAddPosWnd ?? new RelayCommand(obj =>
                {
                    OpenAddPosWindow();
                });
            }
        }

        private void OpenAddPosWindow()
        {
            AddNewPosWindow newPosWindow = new AddNewPosWindow();
            SetCenterPositionAndOpen(newPosWindow);
        }

        public RelayCommand addNewPos;

        public RelayCommand AddNewPos
        {
            get
            {
                return addNewPos ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resStr = "";
                    if (PosName == null || PosName.Replace(" ", "").Length == 0)
                    {

                    }
                    else
                    {
                        resStr = DataWorker.CreatePos(PosName);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }
        #endregion

        #region Пользователь
        private RelayCommand openAddUserWnd;
        public RelayCommand OpenAddUserWnd
        {
            get
            {
                return openAddUserWnd ?? new RelayCommand(obj =>
                {
                    OpenAddUserWindow();
                });
            }
        }

        private void OpenAddUserWindow()
        {
            AddNewUserWindow newUserWindow = new AddNewUserWindow();
            SetCenterPositionAndOpen(newUserWindow);
        }

        public RelayCommand addNewUser;

        public RelayCommand AddNewUser
        {
            get
            {
                return addNewUser ?? new RelayCommand(obj =>
                {
                    Window wnd = obj as Window;
                    string resStr = "";
                    if (LoginUser == null && PassUser == null && FioUser == null && DateRozhUser == null && PositionUser == null || LoginUser.Replace(" ", "").Length == 0 && PassUser.Replace(" ", "").Length == 0)
                    {

                    }
                    else
                    {
                        resStr = DataWorker.CreateUser(LoginUser, PassUser, FioUser, DateRozhUser, PositionUser.Id);
                        UpdateAllDataView();
                        SetNullValuesToProperties();
                        wnd.Close();
                    }
                });
            }
        }
        #endregion

        #region Удаление из БД
        private RelayCommand deleteItem;

        public RelayCommand DeleteItem
        {
            get
            {
                return deleteItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если должность
                    if(SelectedTabItem.Name == "PositionsTab" && SelectedPos != null)
                    {
                        resultStr = DataWorker.DeletePosition(SelectedPos);
                        UpdateAllDataView();
                    }
                    //если РЦ
                    if (SelectedTabItem.Name == "RSTab" && SelectedRs != null)
                    {
                        resultStr = DataWorker.DeleteRs(SelectedRs);
                        UpdateAllDataView();
                    }
                    //если срочность
                    if (SelectedTabItem.Name == "SrokiTab" && SelectedSrok != null)
                    {
                        resultStr = DataWorker.DeleteSrok(SelectedSrok);
                        UpdateAllDataView();
                    }
                    //если сотрудник
                    if (SelectedTabItem.Name == "UsersTab" && SelectedUser != null)
                    {
                        resultStr = DataWorker.DeleteUser(SelectedUser);
                        UpdateAllDataView();
                    }
                    // обновление
                    SetNullValuesToProperties();

                });
            }
        }
        #endregion
        private void SetCenterPositionAndOpen(Window window)
        {
            window.Owner = Application.Current.MainWindow;
            window.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            window.ShowDialog();
        }


        #region updtae views
        private void SetNullValuesToProperties()
        {
            // для РЦ
            Email = null;
            NameRS = 0;
            // для Сроков
            SrokiName = null;
            SrokiColdn = 0;
            
        }
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
