using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    class Sroki
    {
        public int id { get; set; }
        private string name;
        private int coldn;

        public string Name
        {
            get { return name; }
            set { name = value; }

        }

        public int Coldn
        {
            get { return coldn; }
            set { coldn = value; }

        }


        public Sroki() { }

        public Sroki(string name, int coldn)
        {
            this.name = name;
            this.coldn = coldn;
        }
    }
}
