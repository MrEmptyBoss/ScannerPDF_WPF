using ScannerFinalPDF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ScannerFinalPDF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CreateZayvka.xaml
    /// </summary>
    public partial class CreateZayvka : Page
    {
        public CreateZayvka()
        {
            InitializeComponent();
            DataContext = new CreateViewModel(data_table_zayv, red_text, Nshop_TextBlock, CommentZayvki);
        }
    }
}
