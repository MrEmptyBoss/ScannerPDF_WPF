using ScannerFinalPDF.Model.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Логика взаимодействия для CreateReportWindow.xaml
    /// </summary>
    public partial class CreateReportWindow : Window
    {
        public static ObservableCollection<DateTime> SelectedDates { get; set; }
        public CreateReportWindow()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
            SelectedDates = new ObservableCollection<DateTime>();
        }

        private void Calendar_SelectedDatesChanged(object sender, SelectionChangedEventArgs e)
        {
            SelectedDates.Clear();
            foreach (DateTime selectedDate in ((Calendar)sender).SelectedDates)
            {
                SelectedDates.Add(selectedDate);
            }
        }
    }
}
