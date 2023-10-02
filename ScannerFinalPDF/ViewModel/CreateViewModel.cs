using ScannerFinalPDF.Model.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.ViewModel
{
    class CreateViewModel : ViewModelBase
    {
        ApplicationContext db;
        private RS selectedRs;
        private Sroki selectedSroki;

        public ObservableCollection<RS> RsSp { get; set; }
        public ObservableCollection<Sroki> sroki { get; set; }


        public CreateViewModel()
        {
            db = new ApplicationContext();
            db.RS.Load();
            db.Sroki.Load();
            RsSp = db.RS.Local;
            sroki = db.Sroki.Local;

        }

        public RS SelectedRS
        {
            get { return selectedRs; }
            set
            {
                selectedRs = value;
                OnPropertyChanged("SelectedRS");
            }
        }
        public Sroki SelectedSroki
        {
            get { return selectedSroki; }
            set
            {
                selectedSroki = value;
                OnPropertyChanged("SelectedSroki");
            }
        }
    }
}
