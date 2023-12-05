using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View;
using ScannerFinalPDF.View.Pages;

namespace ScannerFinalPDF.ViewModel
{
    class ViewModelControlPanel : ViewModelBase
    {
        private AlertPush alert;
        private ApplicationContext db;
        private RS selectedRs;
        private ObservableCollection<RS> selectedRSs;

        public ObservableCollection<RS> Rs
        {
            get => selectedRSs;
            set
            {
                selectedRSs = value;
                OnPropertyChanged(nameof(Rs));
            }
        }


        public ViewModelControlPanel()
        {
            db = new ApplicationContext();
            db.RS.Load();
            Rs = db.RS.Local;

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

        public ICommand CreateAccB => new RelayCommand(() => CreateAcc());
        public ICommand CreateOpenMessB => new RelayCommand(() => CreateOpenMess());
        public ICommand EditOpenMessB => new RelayCommand(() => EditOpenMess());

        public async void CreateAcc()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog
            {
                DefaultExt = ".txt",
                Filter = "Text files (*.txt)|*.txt"
            };
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                string[] lines = File.ReadLines(filename).ToArray();
                int count = lines.Length;
                int countAcc = count / 5;
                DateTime dd = DateTime.Now;

                await Task.Run(() =>
                {
                    for (int i = 1; i <= countAcc; i++)
                    {
                        SaveUser(lines);
                        lines = lines.Skip(5).ToArray();
                    }
                });

                alert = new AlertPush("Все пользователи добавлены!");
                alert.Show();
            }
            else
            {
                alert = new AlertPush("Вы не выбрали файл!");
                alert.Show();
            }
        }

        private void SaveUser(string[] lines)
        {
            User user = new User(lines[0], lines[1], lines[2], Convert.ToInt32(lines[3]), DateTime.Now, Convert.ToDateTime(lines[4]));
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void CreateOpenMess()
        {
            EmailMess Mess = new EmailMess("0", "Введите");
            Mess.Emailch.Text = "Введите";

            if (Mess.ShowDialog() == true)
            {

            }
            else
            {
                db = new ApplicationContext();
                db.RS.Load();
                Rs = db.RS.Local;
            }
        }

        public void EditOpenMess()
        {
            if (selectedRs != null)
            {
                EmailMess Mess = new EmailMess(Convert.ToString(selectedRs.Name), selectedRs.Email);
                Mess.addsavebtn.Content = "Сохранить";
                Mess.nname.Text = "Изменение РЦ";
                Mess.RSTch.Text = Convert.ToString(selectedRs.Name);
                Mess.Emailch.Text = selectedRs.Email;

                if (Mess.ShowDialog() == true)
                {

                }
                else
                {
                    db = new ApplicationContext();
                    db.RS.Load();
                    Rs = db.RS.Local;
                }
            }
            else
            {
                alert = new AlertPush("Выберите почту для изменения!");
                alert.Show();
            }
        }
    }
}
