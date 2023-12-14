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
    /// Логика взаимодействия для AddNewPosWindow.xaml
    /// </summary>
    public partial class AddNewPosWindow : Window
    {
        public AddNewPosWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
        }
    }
}
