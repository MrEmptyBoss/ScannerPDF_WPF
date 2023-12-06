using ScannerFinalPDF.ViewModel;
using System;

namespace ScannerFinalPDF.Model.Data
{
    public class Zayvka
    {
        public int Id { get; set; }
        public int IdRS { get; set; }
        public virtual RS Rs { get; set; }
        public int IdUsers { get; set; }
        public virtual User Users { get; set; }
        public string NameRequest { get; set; }
        public int IdSroki { get; set; }
        public virtual Sroki Sroki { get; set; }
        public int NShop { get; set; }
        public DateTime DatePriem { get; set; }
        public DateTime? DateDostav { get; set; }
        public DateTime? DateClose { get; set; }
        public DateTime DatePlanov { get; set; }
        public int NumberTruck { get; set; }
        public int IdSotr { get; set; }
        public virtual User Sotr { get; set; }
        public string Status { get; set; }
        public string Commentz { get; set; }


        public Zayvka() { }

        public Zayvka(int idRS, int idUsers, string nameRequest, int idSroki, int nShop, DateTime datePriem, DateTime dateDostav, DateTime dateClose, DateTime datePlanov, int numberTruck, int idSotr, string status, string commentz)
        {
            IdRS = idRS;
            IdUsers = idUsers;
            NameRequest = nameRequest;
            IdSroki = idSroki;
            NShop = nShop;
            DatePriem = datePriem;
            DateDostav = dateDostav;
            DateClose = dateClose;
            DatePlanov = datePlanov;
            NumberTruck = numberTruck;
            IdSotr = idSotr;
            Status = status;
            Commentz = commentz;
        }
    }
}