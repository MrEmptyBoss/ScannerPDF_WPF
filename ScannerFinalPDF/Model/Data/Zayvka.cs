using ScannerFinalPDF.ViewModel;
using System;

namespace ScannerFinalPDF.Model.Data
{
    public class Zayvka
    {
        public int Id { get; set; }
        public virtual RS Rs { get; set; }
        public virtual User Users { get; set; }
        public string NameRequest { get; set; }
        public virtual Sroki Sroki { get; set; }
        public int NShop { get; set; }
        public DateTime DatePriem { get; set; }
        public DateTime? DateDostav { get; set; }
        public DateTime? DateClose { get; set; }
        public DateTime DatePlanov { get; set; }
        public int NumberTruck { get; set; }
        public virtual User Sotr { get; set; }
        public string Status { get; set; }
        public string Commentz { get; set; }


        public Zayvka() { }
    }
}