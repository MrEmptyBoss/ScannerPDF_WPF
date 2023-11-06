using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Xml.Linq;
using GalaSoft.MvvmLight.Command;
using Microsoft.EntityFrameworkCore;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View;
using ScannerFinalPDF.View.Pages;

namespace ScannerFinalPDF.ViewModel
{

    class ViewModelControlPanel : ViewModelBase
    {
        AlertPush alert;
        ApplicationContext db;
        private RS selectedRs;
        private ObservableCollection<RS> selectedRSs;
        public ObservableCollection<RS> Rs
        {
            get
            {
                return selectedRSs;
            }
            set
            {
                selectedRSs = value;
                OnPropertyChanged("Rs");
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
            get { return selectedRs; }
            set
            {
                selectedRs = value;
                OnPropertyChanged("SelectedRS");
            }
        }

        public ICommand CreateAccB
        {
            get
            {
                return new RelayCommand(() => CreateAcc());
            }
        }

        public ICommand CreateOpenMessB
        {
            get
            {
                return new RelayCommand(() => CreateOpenMess());
            }
        }

        public ICommand EditOpenMessB
        {
            get
            {
                return new RelayCommand(() => EditOpenMess());
            }
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
            if(selectedRs != null)
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

        public void CreateAcc()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();

            if (result == true)
            {
                string filename = dlg.FileName;
                string[] lines = File.ReadLines(filename).ToArray();
                int count = lines.Length;
                int countAcc = count / 5;
                DateTime dd = DateTime.Now;
                for (int i = 1; i<= countAcc; i++)
                {
                    //костыль
                    if(i == 1)
                    {
                        User user = new User(lines[0], lines[1], lines[2], Convert.ToInt32(lines[3]), dd, Convert.ToDateTime(lines[4]));
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    else
                    {
                        lines = lines.Skip(5).ToArray();
                        User user = new User(lines[0], lines[1], lines[2], Convert.ToInt32(lines[3]), dd, Convert.ToDateTime(lines[4]));
                        db.Users.Add(user);
                        db.SaveChanges();
                    }
                    
                }
                alert = new AlertPush("Все пользователи добавлены!");
                alert.Show();

            }

            else
            {
                alert = new AlertPush("Вы не выбрали файл!");
                alert.Show();
                List<User> users = db.Users.ToList();

            }

        }
    }
}
