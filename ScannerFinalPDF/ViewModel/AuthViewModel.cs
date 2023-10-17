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
                //исправить!!!!
                var s = secondForm.OpenProfile.Template;
                var myTextBlock = (TextBlock)s.FindName("nameuser", secondForm.OpenProfile);
                myTextBlock.Text = authUser.Fio;
                if (authUser.Position == 0)
                {
                    
                    secondForm.panelupr.Visibility = Visibility.Hidden;
                    secondForm.paneluprb.Visibility = Visibility.Hidden;

                    secondForm.ZakrB.Visibility = Visibility.Hidden;
                    secondForm.ZakrZ.Visibility = Visibility.Hidden;

                    secondForm.OpenZB.Visibility = Visibility.Hidden;
                    secondForm.OpenZ.Visibility = Visibility.Hidden;

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
