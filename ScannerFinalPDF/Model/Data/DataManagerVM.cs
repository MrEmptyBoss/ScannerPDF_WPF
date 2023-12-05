using GalaSoft.MvvmLight;
using ScannerFinalPDF.ViewModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    public class DataManagerVM : INotifyPropertyChanged
    {
        public List<Zayvka> zayvkas = DataWorker.GetAllZayvka();
        public List<Sroki> srokis = DataWorker.GetAllsroki();
        public List<RS> Rs = DataWorker.GetAllrs();


        public List<Zayvka> AllZayvki
        {
            get { return zayvkas; }
            set
            {
                zayvkas = value;
                OnPropertyChanged(nameof(zayvkas));
            }
        }

        public List<Sroki> AllSroki
        {
            get { return srokis; }
            set
            {
                srokis = value;
                OnPropertyChanged(nameof(srokis));
            }
        }

        public List<RS> AllRs
        {
            get { return Rs; }
            set
            {
                Rs = value;
                OnPropertyChanged(nameof(Rs));
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PropertyName = null)
        {
            if (Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(PropertyName);
            return true;
        }
    }

}
