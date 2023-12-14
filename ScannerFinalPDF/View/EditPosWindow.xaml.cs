﻿using ScannerFinalPDF.Model.Data;
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
    /// Логика взаимодействия для EditPosWindow.xaml
    /// </summary>
    public partial class EditPosWindow : Window
    {
        public EditPosWindow(Position positionToEdit)
        {
            InitializeComponent();
            DataContext = new DataManagerVM();
            DataManagerVM.SelectedPos = positionToEdit;
            DataManagerVM.PosName = positionToEdit.Name;

        }
    }
}
