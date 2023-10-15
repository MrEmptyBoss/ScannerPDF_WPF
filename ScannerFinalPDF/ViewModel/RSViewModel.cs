using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ScannerFinalPDF.Model.Data;

namespace ScannerFinalPDF.ViewModel
{
    class RSViewModel : ViewModelBase
    {
        ApplicationContext db;
        public string Email { get; set; }
        public string Name { get; set; }

        public string Emailch;
        public int RSTch;
        public RSViewModel(TextBlock emailch, TextBlock rSTch)
        {
            if (emailch.Text == "Введите email")
            { 
            
            }
            else
            {
                Emailch = emailch.Text;
                RSTch = Convert.ToInt32(rSTch.Text);
            }
            db = new ApplicationContext();
        }

        public ICommand AddRsB
        {
            get
            {
                return new RelayCommand(() => AddRs());
            }
        }

        public void AddRs()
        {
            RS rs = null;
            using (db)
            {
                rs = db.RS.Where(b => b.Email == Emailch && b.Name == RSTch).FirstOrDefault();
                if (rs != null)
                {
                    rs.Email = Email;
                    rs.Name = Convert.ToInt32(Name);
                    db.SaveChanges();
                    MessageBox.Show("Изменен РЦ");
                }
                else
                {
                    string email = Email;
                    int name = Convert.ToInt32(Name);
                    RS rScurr = new RS(name, email);
                    db.RS.Add(rScurr);
                    db.SaveChanges();
                    MessageBox.Show("Добавлен новый РЦ");
                }
            }
       

            foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
            
        }

    }
}
