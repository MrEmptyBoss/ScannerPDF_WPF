using ScannerFinalPDF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ScannerFinalPDF.Model.Data
{
    public class Zayvka
    {
        public int Id { get; set; }

        public int RsId { get; set; }
        public virtual RS Rs { get; set; }
        public string NameRequest { get; set; }
        public int SrokiId { get; set; }
        public virtual Sroki Sroki { get; set; }
        public int NShop { get; set; }
        public DateTime DatePriem { get; set; }
        public DateTime? DateDostav { get; set; }
        public DateTime? DateClose { get; set; }
        public DateTime DatePlanov { get; set; }
        public int? NumberTruck { get; set; }
        public int SotrId { get; set; }
        public virtual User Sotr { get; set; }
        public List<Maket> Makets { get; set; }
        public string Status { get; set; }
        public string Commentz { get; set; }
        [NotMapped]
        public RS RsZayvkaiId
        {
            get
            {
                return DataWorker.GetRSid(RsId);
            }
        }

        [NotMapped]
        public Sroki SrokiZayvkaiId
        {
            get
            {
                return DataWorker.GetSrokiId(SrokiId);
            }
        }


        public Zayvka() { }
    }
}