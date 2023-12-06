using ScannerFinalPDF.Model.ViewModel;
using System;

namespace ScannerFinalPDF.Model.Data
{
    public class Maket : DataManagerVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Length { get; set; }
        public int Width { get; set; }
        public int Colstr { get; set; }
        private int colotp;
        private int count;
        public int Colotp
        {
            get { return colotp; }
            set
            {
                colotp = value;
                OnPropertyChanged(nameof(Count));
            }
        }
        public int Count
        {
            get { return Colstr * Colotp; }
            set { count = Colstr * Colotp; }
        }
        public int Fill { get; set; }
        public double Kvadr { get; set; }
        public virtual Zayvka IdZayvki { get; set; }

        public Maket() { }

        public Maket(string name, int length, int width, int colstr, int colotp, int fill, double kvadr, Zayvka idRequest)
        {
            Name = name;
            Length = length;
            Width = width;
            Colstr = colstr;
            Colotp = colotp;
            Fill = fill;
            Kvadr = kvadr;
            IdZayvki = idRequest;
        }
    }
}
