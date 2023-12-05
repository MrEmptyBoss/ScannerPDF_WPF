using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScannerFinalPDF.Model.Data
{
    class DataWorker
    {

        public static RS GetRSid(int id)
        {
            using(ApplicationContext db = new ApplicationContext())
            {
                RS rs = db.RS.FirstOrDefault(p => p.id == id);
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

        public static void UpdateModel()
        {
            // Логика обновления модели
            // Например, обновление списка данных и т.д.
        }
    }
}
