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

namespace ScannerFinalPDF.ViewModel
{
    class AuthViewModel : ViewModelBase
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
                return new RelayCommand(() => AuthObr());
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
                authUser = db.Users.Where(b => b.Login == login && b.Pass == pass).FirstOrDefault();
            }
            if (authUser != null)
            {
                secondForm = new MainHome();
                secondForm.Show();
                secondForm.nameuser.Text = authUser.Fio;
                if(authUser.Position == 0)
                {
                    secondForm.panelupr.Visibility = Visibility.Hidden;
                    secondForm.paneluprb.Visibility = Visibility.Hidden;

                }
                else
                {

                }
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
