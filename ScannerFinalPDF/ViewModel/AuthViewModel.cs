using ScannerFinalPDF.Model.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using System.Windows;
using ScannerFinalPDF.View;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using ScannerFinalPDF.View.Pages;
using ScannerFinalPDF.Model.ViewModel;

namespace ScannerFinalPDF.ViewModel
{
    class AuthViewModel : DataManagerVM
    {
        MainHome secondForm;

        public string Login { get; set; }
        public string Password { get; set; }
        public AuthViewModel()
        {

        }

        public ICommand AuthObrB
        {
            get
            {
                return new GalaSoft.MvvmLight.CommandWpf.RelayCommand(() => AuthObr());
            }
        }

        // доделать доступ
        public void AuthObr()
        {
            string login = Login;
            string pass = Password;
            User authUser = null;
            using(ApplicationContext db = new ApplicationContext())
            {
                List<User> users = DataWorker.GetAlluser();
                authUser = users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
            }
            if (authUser != null)
            {
                secondForm = new MainHome();
                secondForm.Show();
                //if (authUser.Position == 0)
                //{
                    


                //}
                //else
                //{

                //}
                foreach (Window item in Application.Current.Windows)
                {
                    if (item.DataContext == this) item.Close();
                }
            }
            else
            {
                MessageBox.Show("Вы ввели неккоректные данные");
            }
            
        }
    }
}
