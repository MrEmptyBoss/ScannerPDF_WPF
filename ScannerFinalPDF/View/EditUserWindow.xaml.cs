using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ScannerFinalPDF.View
{
    /// <summary>
    /// Логика взаимодействия для EditUserWindow.xaml
    /// </summary>
    public partial class EditUserWindow : Window
    {
        public EditUserWindow(User userToEdit)
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
            DataManagerVM.SelectedUser = userToEdit;
            DataManagerVM.LoginUser = userToEdit.Login;
            DataManagerVM.FioUser = userToEdit.Fio;
            DataManagerVM.PassUser = userToEdit.Pass;
            DataManagerVM.DateRozhUser = userToEdit.Date_rozh;

        }
    }
}
