using ScannerFinalPDF.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    class Maket:DataManagerVM
    {
        public int id { get; set; }

        private string name;
        private int length;
        private int width;
        private int colstr;
        private int colotp;
        private int count;
        private int fill;
        private double kvadr;
        private int idrequest;

        public string Name
        {
            get { return name; }
            set { name = value; }

        }
        public int Length
        {
            get { return length; }
            set { length = value; }

        }
        public int Width
        {
            get { return width; }
            set { width = value; }

        }
        public int Colstr
        {
            get { return colstr; }
            set { colstr = value; }

        }
        public int Colotp
        {
            get { return colotp; }
            set { colotp = value;
                OnPropertyChanged("Count");
            }

        }
        public int Count
        {
            get { return colstr* colotp; }
            set { count = colstr * colotp; }
        }
        public int Fill
        {
            get { return fill; }
            set { fill = value; }

        }
        public double Kvadr
        {
            get { return kvadr; }
            set { kvadr = value; }

        }

        public int Idrequest
        {
            get { return idrequest; }
            set { idrequest = value; }

        }

        public Maket() { }

        public Maket(string name, int length, int width, int colstr, int colotp, int fill, double kvadr, int idrequest)
        {
            this.name = name;
            this.length = length;
            this.width = width;
            this.colstr = colstr;
            this.colotp = colotp;
            this.count = colstr*colotp;
            this.fill = fill;
            this.kvadr = kvadr;
            this.idrequest = idrequest;

        }

    }
}
