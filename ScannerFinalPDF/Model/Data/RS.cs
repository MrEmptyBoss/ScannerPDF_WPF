using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    class RS
    {
        public int id { get; set; }

        private int name;
        private string email;


        public int Name
        {
            get { return name; }
            set { name = value; }

        }

        public string Email
        {
            get { return email; }
            set { email = value; }

        }

        public RS() { }

        public RS(int name, string email)
        {
            this.name = name;
            this.email = email;
        }
    }
}
