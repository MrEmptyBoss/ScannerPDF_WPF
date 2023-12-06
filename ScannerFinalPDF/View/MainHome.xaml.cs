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
using ScannerFinalPDF.Model.Data;
using ScannerFinalPDF.Model.ViewModel;
using ScannerFinalPDF.ViewModel;

namespace ScannerFinalPDF.View
{
    /// <summary>
    /// Логика взаимодействия для MainHome.xaml
    /// </summary>
    public partial class MainHome : Window
    {
        Window creatingForm;
        public static ListView AllUsersView;
        public static ListView AllPositionsView;
        public static ListView AllRsView;
        public static ListView AllSrokiView;
        public static ListView AllZayvkiView;

        public MainHome()
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
            AllUsersView = ViewAllUsers;
            AllRsView = ViewAllRS;
            AllSrokiView = ViewAllSroki;
            AllZayvkiView = ViewAllZayvki;
            AllPositionsView = ViewAllPositions;


        }

        public Window setCreatingForm
        {
            get { return creatingForm; }
            set { creatingForm = value; }
        }

        private void ToolBar_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }

        private void MinButt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void CloseButt_MouseDown(object sender, MouseButtonEventArgs e)
        {
            this.Close();
        }
    }
}
