using ScannerFinalPDF.Model.ViewModel;
using System;

namespace ScannerFinalPDF.Model.Data
{
    public class Maket
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

    }
}
