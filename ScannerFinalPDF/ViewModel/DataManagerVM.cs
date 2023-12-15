using GalaSoft.MvvmLight;
using Microsoft.Win32;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.Model.Documents;
using ScannerFinalPDF.Model.Scanner;
using ScannerFinalPDF.View;
using ScannerFinalPDF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Data.Entity.Migrations.Model;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

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
        public static string SrokiName { get; set; }
        public static int SrokiColdn { get; set; }
        // свойства РЦ
        public static int NameRS { get; set; }
        public static string Email { get; set; }
        // свойства должности
        public static string PosName { get; set; }
        //  свойства пользователя
        public static string LoginUser { get; set; }
        public static string PassUser { get; set; }
        public static string FioUser { get; set; }
        public static DateTime DateRozhUser { get; set; }
        public static Position PositionUser { get; set; }
        // макеты
        private List<Maket> scanner_Maket;
        public Maket SelectedMaket { get; set; }
        //свойства для заявки
        public RS SelectedRSZayvka { get; set; }
        public int NshopZ { get; set; }

        public Sroki SelectedSrokZayvka { get; set ; }

        // свойства для выделенных элементов 
        public TabItem SelectedTabItem { get; set; }
        public static User SelectedUser { get; set; }
        public static Position SelectedPos { get; set; }
        public static Sroki SelectedSrok { get; set; }
        public static RS SelectedRs { get; set; }
        public Zayvka SelectedZayvka { get; set; }

        //свойства для накладной


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

        private void OpenEditSrokWindow(Sroki sroki)
        {
            EditSrokiWindow EditNewSrokiWindow = new EditSrokiWindow(sroki);
            SetCenterPositionAndOpen(EditNewSrokiWindow);
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


        private void OpenEditRsWindow(RS rS)
        {
            EditRsWindow editRsWindow = new EditRsWindow(rS);
            SetCenterPositionAndOpen(editRsWindow);
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

        private void OpenEditPosWindow(Position position)
        {
            EditPosWindow editPosWindow = new EditPosWindow(position);
            SetCenterPositionAndOpen(editPosWindow);
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

        private void OpenEditUserWindow(User user)
        {
            EditUserWindow editUserWindow = new EditUserWindow(user);
            SetCenterPositionAndOpen(editUserWindow);
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
                        //MessageBox.Show(MainHome.Profile.Fio);
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
                    // ели заявка
                    if (SelectedTabItem.Name == "Zayvki" && SelectedZayvka != null)
                    {
                        resultStr = DataWorker.DeleteZayvka(SelectedZayvka);
                        UpdateAllDataView();
                    }
                    // обновление
                    SetNullValuesToProperties();

                });
            }
        }
        #endregion

        #region Редактирование в БД
        private RelayCommand editItem;

        public RelayCommand EditItem
        {
            get
            {
                return editItem ?? new RelayCommand(obj =>
                {
                    string resultStr = "Ничего не выбрано";
                    //если должность
                    if (SelectedTabItem.Name == "PositionsTab" && SelectedPos != null)
                    {
                        OpenEditPosWindow(SelectedPos);
                    }
                    //если РЦ
                    if (SelectedTabItem.Name == "RSTab" && SelectedRs != null)
                    {
                        OpenEditRsWindow(SelectedRs);
                    }
                    //если срочность
                    if (SelectedTabItem.Name == "SrokiTab" && SelectedSrok != null)
                    {
                        OpenEditSrokWindow(SelectedSrok);
                    }
                    //если сотрудник
                    if (SelectedTabItem.Name == "UsersTab" && SelectedUser != null)
                    {
                        OpenEditUserWindow(SelectedUser);
                    }

                });
            }
        }
        #endregion

        #region Команды редактирования
        private RelayCommand editPos;
        public RelayCommand EditPos
        {
            get
            {
                return editPos ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Должность не выбрана";
                    if(SelectedPos != null)
                    {
                        resultStr = DataWorker.EditPos(SelectedPos, PosName);
                        UpdateAllDataView();
                        window.Close();
                    }
                    else
                    {

                    }
                });
            }
        }

        private RelayCommand editRs;
        public RelayCommand EditRs
        {
            get
            {
                return editRs ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "РЦ не выбран";
                    if (SelectedRs != null)
                    {
                        resultStr = DataWorker.EditRS(SelectedRs, NameRS, Email);
                        UpdateAllDataView();
                        window.Close();
                    }
                    else
                    {

                    }
                });
            }
        }

        private RelayCommand editSroki;
        public RelayCommand EditSroki
        {
            get
            {
                return editSroki ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Срочность не выбрана";
                    if (SelectedSrok != null)
                    {
                        resultStr = DataWorker.EditSroki(SelectedSrok, SrokiName, SrokiColdn);
                        UpdateAllDataView();
                        window.Close();
                    }
                    else
                    {

                    }
                });
            }
        }

        private RelayCommand editUser;
        public RelayCommand EditUser
        {
            get
            {
                return editUser ?? new RelayCommand(obj =>
                {
                    Window window = obj as Window;
                    string resultStr = "Сотрудник не выбран";
                    if (SelectedUser != null)
                    {
                        resultStr = DataWorker.EditUser(SelectedUser, LoginUser, PassUser, FioUser, DateRozhUser, PositionUser.Id);
                        UpdateAllDataView();
                        window.Close();
                    }
                    else
                    {

                    }
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

        #region Алгоритм загрузки заявки
        private RelayCommand openAddZayvkaWnd;
        public RelayCommand OpenAddZayvkaWnd
        {
            get
            {
                return openAddZayvkaWnd ?? new RelayCommand(obj =>
                {
                    OpenAddZayvkaWindow();
                });
            }
        }

        private void OpenAddZayvkaWindow()
        {
            AddNewZayvkaWindow newZayvkaWindow = new AddNewZayvkaWindow();
            SetCenterPositionAndOpen(newZayvkaWindow);
        }

        private RelayCommand uploadMaket;

        public RelayCommand UploadMaket
        {
            get
            {
                return uploadMaket ?? new RelayCommand(obj =>
                {
                    string folderPath = OpenDialog();
                    if (folderPath != null)
                    {
                        if (scanner_Maket != null)
                        {
                            scanner_Maket.Clear();
                        }
                        Scanner_Filles scanner_Filles = new Scanner_Filles();
                        scanner_Maket = scanner_Filles.InfoFiles(folderPath);
                        AddNewZayvkaWindow.AllMaketsView.ItemsSource = null;
                        AddNewZayvkaWindow.AllMaketsView.Items.Clear();
                        AddNewZayvkaWindow.AllMaketsView.ItemsSource = scanner_Maket;
                        AddNewZayvkaWindow.Red_Text.Opacity = 1;
                        AddNewZayvkaWindow.AllMaketsView.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        MessageBox.Show("Не выбрали папку");
                    }

                });
            }
        }

        private RelayCommand createZayvkaBtn;

        public RelayCommand CreateZayvkaBtn
        {
            get
            {
                return createZayvkaBtn ?? new RelayCommand(obj =>
                {
                    if(scanner_Maket != null)
                    {
                        DateTime now = DateTime.Now;
                        DataWorker.CreateZayvka(SelectedRSZayvka.Id, SelectedSrokZayvka.id, MainHome.Profile.id, NshopZ, now.AddDays(SelectedSrokZayvka.Coldn), new TextRange(AddNewZayvkaWindow.CommentZayvkiR.Document.ContentStart, AddNewZayvkaWindow.CommentZayvkiR.Document.ContentEnd).Text, scanner_Maket);
                        UpdateAllDataView();
                    }

                });
            }
        }

        // открытие проводника
        public static string OpenDialog()  // Открытие проводника
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

        public static string SaveDialog()  // Открытие проводника
        {
            string filePath = null;

            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Title = "Выберите место и имя файла Excel",
                Filter = "Файлы Excel (*.xlsx)|*.xlsx|Все файлы (*.*)|*.*"
            };

            Nullable<bool> result = saveFileDialog.ShowDialog();
            if (result == true)
            {
                filePath = saveFileDialog.FileName;
            }
            return filePath;
        }


        #endregion

        #region Алгоритм отмены/одобрения/закрытия заявки
        private RelayCommand zayvkaRevoke;
        public RelayCommand ZayvkaRevoke
        {
            get
            {
                return zayvkaRevoke ?? new RelayCommand(obj =>
                {
                    zayvkaRevokeAlg();
                });
            }
        }

        private void zayvkaRevokeAlg()
        {
            string res = DataWorker.EditZayvka(SelectedZayvka, "Отменено");
            UpdateAllDataView();
            MessageBox.Show(res);
        }

        private RelayCommand zayvkaVrabote;
        public RelayCommand ZayvkaVrabote
        {
            get
            {
                return zayvkaVrabote ?? new RelayCommand(obj =>
                {
                    zayvkaVrabAlg();
                });
            }
        }

        private void zayvkaVrabAlg()
        {
            string res = DataWorker.EditZayvka(SelectedZayvka, "В работе");
            UpdateAllDataView();
            MessageBox.Show(res);
        }

        private RelayCommand zayvkaZakr;
        public RelayCommand ZayvkaZakr
        {
            get
            {
                return zayvkaZakr ?? new RelayCommand(obj =>
                {
                    zayvkaZakrAlg();
                });
            }
        }

        private void zayvkaZakrAlg()
        {
            string res = DataWorker.EditZayvka(SelectedZayvka, "Завершено");
            UpdateAllDataView();
            MessageBox.Show(res);
        }

        #endregion

        #region Алгоритм создания накладной
        private RelayCommand openCreateNaklWnd;
        public RelayCommand OpenCreateNaklWnd
        {
            get
            {
                return openCreateNaklWnd ?? new RelayCommand(obj =>
                {
                    OpenCreateNaklWindow();
                });
            }
        }

        private void OpenCreateNaklWindow()
        {
            CreateNaklWindow newNaklWindow = new CreateNaklWindow();
            SetCenterPositionAndOpen(newNaklWindow);
        }

        private RelayCommand createNakl;

        public RelayCommand CreateNakl
        {
            get
            {
                return createNakl ?? new RelayCommand(obj =>
                {
                    if (CreateNaklWindow.SelectedDates != null)
                    {
                        string folderPath = SaveDialog();
                        Nakladnay_Excel nakladnay_Excel = new Nakladnay_Excel();
                        if (CreateNaklWindow.SelectedDates.Count == 1)
                        {
                            List<Zayvka> zayvkas = DataWorker.GetZayvkaRSDate(CreateNaklWindow.SelectedDates[0].Date, SelectedRs.Id);
                            nakladnay_Excel.CreateNakladnDoc(folderPath, zayvkas);
                        }
                        else if (CreateNaklWindow.SelectedDates.Count == 2)
                        {
                            List<Zayvka> zayvkas = DataWorker.GetZayvkaRSDates(CreateNaklWindow.SelectedDates[0].Date, CreateNaklWindow.SelectedDates[1].Date, SelectedRs.Id);
                            nakladnay_Excel.CreateNakladnDoc(folderPath, zayvkas);
                        }
                        else
                        {
                            MessageBox.Show("Выберите две даты");
                        }
                        
                    }
                    else
                    {
                        MessageBox.Show("Не выбрали дату");
                    }

                });
            }
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
