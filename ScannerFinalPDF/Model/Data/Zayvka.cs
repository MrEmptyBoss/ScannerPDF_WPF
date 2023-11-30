using ScannerFinalPDF.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    class Zayvka: ViewModelBase
    {
        public int id { get; set; }

        private int idRS;
        private int idusers;
        private string namerequest;
        private int idsroki;
        private int nshop;
        private DateTime datepriem;
        private DateTime datedostav;
        private DateTime dateclose;
        private DateTime dateplanov;
        private int numbertruck;
        private int idsotr;
        private string status;
        private string commentz;


        public RS ZayvkaRS
        {
            get
            {
                return DataWorker.GetRSid(idRS);
            }
        }
        public Sroki ZayvkaSroki
        {
            get
            {
                return DataWorker.GetSrokiId(idsroki);
            }
        }


        public int IdRS
        {
            get { return idRS; }
            set { idRS = value; }

        }
        public int Idusers
        {
            get { return idusers; }
            set { idusers = value; }

        }
        public string Namerequest
        {
            get { return namerequest; }
            set { namerequest = value; }

        }
        public int Idsroki
        {
            get { return idsroki; }
            set { idsroki = value; }

        }
        public int Nshop
        {
            get { return nshop; }
            set { nshop = value; }

        }
        public DateTime Datepriem
        {
            get { return datepriem; }
            set { datepriem = value; }

        }
        public DateTime Datedostav
        {
            get { return datedostav; }
            set { datedostav = value; }

        }
        public DateTime Dateclose
        {
            get { return dateclose; }
            set { dateclose = value; }

        }
        public DateTime Dateplanov
        {
            get { return dateplanov; }
            set { dateplanov = value; }

        }
        public int Numbertruck
        {
            get { return numbertruck; }
            set { numbertruck = value; }

        }
        public int Idsotr
        {
            get { return idsotr; }
            set { idsotr = value; }

        }

        public string Status
        {
            get { return status; }
            set { status = value; }

        }
        public string Commentz
        {
            get { return commentz; }
            set { commentz = value; }

        }
        public Zayvka() { }

        public Zayvka(int idRS, int idusers, string namerequest, int idsroki, int nshop, DateTime datepriem, DateTime datedostav, DateTime dateclose, DateTime dateplanov, int numbertruck, int idsotr, string status, string commentz)
        {
            this.idRS = idRS;
            this.idusers = idusers;
            this.namerequest = namerequest;
            this.idsroki = idsroki;
            this.nshop = nshop;
            this.datepriem = datepriem;
            this.dateclose = dateclose;
            this.dateplanov = dateplanov;
            this.numbertruck = numbertruck;
            this.idsotr = idsotr;
            this.status = status;
            this.commentz = commentz;
        }

    }
}
