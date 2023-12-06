using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    public class User
    {
        public int id {  get; set; }

        private string login, pass, fio;

        public string Login
        {
            get { return login; }
            set { login = value; }

        }

        public string Pass
        {
            get { return pass; }
            set { pass = value; }

        }

        public string Fio
        {
            get { return fio; }
            set { fio = value; }

        }

        private int position;

        public int Position
        {
            get { return position; }
            set { position = value; }

        }

        private DateTime date_create, date_rozh;

        public DateTime Date_create
        {
            get { return date_create; }
            set { date_create = value; }

        }

        public DateTime Date_rozh
        {
            get { return date_rozh; }
            set { date_rozh = value; }

        }

        public User() { }

        public User(string login, string pass, string fio, int position, DateTime date_create, DateTime date_rozh)
        {
            this.login = login;
            this.pass = pass;
            this.fio = fio;
            this.position = position;
            this.date_create = date_create;
            this.date_rozh = date_rozh;
        }
    }
}
