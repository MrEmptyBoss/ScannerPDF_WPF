using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    class DataWorker
    {
        //получить все заявки
        public static List<Zayvka> GetAllZayvka()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Zayvka.ToList();
                return result;
            }
        }
        //получить все РЦ
        public static List<RS> GetAllrs()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.RS.ToList();
                return result;
            }
        }
        //получить все сроки
        public static List<Sroki> GetAllsroki()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Sroki.ToList();
                return result;
            }
        }

        public static RS GetRSid(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                RS rs = db.RS.FirstOrDefault(p => p.Id == id);
                return rs;
            }
            
        }
        public static Sroki GetSrokiId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                Sroki sr = db.Sroki.FirstOrDefault(p => p.id == id);
                return sr;
            }

        }
        public static User GetUserId(int id)
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                User user = db.Users.FirstOrDefault(p => p.id == id);
                return user;
            }

        }
    }
}
