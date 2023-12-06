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
        public int Colotp { get; set; }
        public int Count { get; set; }
        public int Fill { get; set; }
        public double Kvadr { get; set; }
        public int ZayvkaId { get; set; }
        public virtual Zayvka Zayvka { get; set; }

        public Maket() { }

    }
}
