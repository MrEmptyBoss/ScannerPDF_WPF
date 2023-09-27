using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using GalaSoft.MvvmLight.Command;
using ScannerFinalPDF.Model.Data;

namespace ScannerFinalPDF.ViewModel
{
    class RSViewModel : ViewModelBase
    {
        ApplicationContext db;
        public string Email { get; set; }
        public string Name { get; set; }

        public RSViewModel()
        {
            db = new ApplicationContext();
        }

        public ICommand AddRsB
        {
            get
            {
                return new RelayCommand(() => AddRs());
            }
        }

        public void AddRs()
        {
            string email = Email;
            int name = Convert.ToInt32(Name);
            RS rScurr = new RS(name, email);
            db.RS.Add(rScurr);
            db.SaveChanges();
        }

    }
}
