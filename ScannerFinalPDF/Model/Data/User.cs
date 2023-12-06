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

        public string Login { get; set; }
        public string Pass { get; set; }
        public string Fio { get; set; }

        public Position Position { get; set; }

        public DateTime Date_create { get; set; }
        public DateTime Date_rozh { get; set; }


        public User() { }

        public User(string login, string pass, string fio, Position position, DateTime date_create, DateTime date_rozh)
        {
            Login = login;
            Pass = pass;
            Fio = fio;
            Position = position;
            Date_create = date_create;
            Date_rozh = date_rozh;
        }
    }
}
