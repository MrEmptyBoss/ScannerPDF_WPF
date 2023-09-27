﻿using System;
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
        ApplicationContext db;
        private RS selectedRs;
        public ObservableCollection<RS> Rs { get; set; }

        public ViewModelControlPanel()
        {
            db = new ApplicationContext();
            cmbx();
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

        public void cmbx()
        {
            db = new ApplicationContext();
            db.RS.Load();
            Rs = db.RS.Local;

        }

        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
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

        public void CreateOpenMess()
        {
            EmailMess Mess = new EmailMess();
            Mess.Show();
        }

        public void CreateAcc()
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".txt";
            dlg.Filter = "Text files (*.txt)|*.txt";
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
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

                MessageBox.Show("Все пользователи добавлены!");

            }

            else
            {
                MessageBox.Show("Вы не выбрали файл!");
                List<User> users = db.Users.ToList();

            }

        }
    }
}
