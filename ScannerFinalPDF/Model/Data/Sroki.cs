using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    public class Sroki
    {
        public int id { get; set; }
        public string Name { get; set; }
        public int Coldn { get; set; }


        public Sroki() { }

        public Sroki(string name, int coldn)
        {
            this.Name = name;
            this.Coldn = coldn;
        }
    }
}
