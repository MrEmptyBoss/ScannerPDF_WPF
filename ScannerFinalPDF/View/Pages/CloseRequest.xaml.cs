using ScannerFinalPDF.ViewModel;
using System.Windows.Controls;

namespace ScannerFinalPDF.View.Pages
{
    /// <summary>
    /// Логика взаимодействия для CloseRequest.xaml
    /// </summary>
    public partial class CloseRequest : Page
    {
        
        public CloseRequest()
        {
            InitializeComponent();
            DataContext = new ViewModelCloseRequest(data_table_zayv);
            
        }


    }
}
