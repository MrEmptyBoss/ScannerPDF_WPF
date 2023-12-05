using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Messaging;
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.View;

namespace ScannerFinalPDF.ViewModel
{
    class RSViewModel : DataManagerVM
    {
        AlertPush alert;
        ApplicationContext db;
        public string Email { get; set; }
        public string Name { get; set; }

        public string Emailch;
        public int RSTch;
        public RSViewModel(string emailch, string rSTch)
        {
            db = new ApplicationContext();
            Emailch = emailch;
            RSTch = Convert.ToInt32(rSTch);
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
                    alert = new AlertPush("Изменен РЦ, обновите список");
                    alert.Show();
                }
                else
                {
                    string email = Email;
                    int name = Convert.ToInt32(Name);
                    RS rScurr = new RS(name, email);
                    db.RS.Add(rScurr);
                    db.SaveChanges();
                    alert = new AlertPush("Добавлен новый РЦ, обновите список");
                    alert.Show();
                }
            }
       

            foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
            
        }

    }
}
