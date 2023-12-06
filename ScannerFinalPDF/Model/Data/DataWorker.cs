using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        //получить всех пользователей
        public static List<User> GetAlluser()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Users.ToList();
                return result;
            }
        }

        //получить все должности
        public static List<Position> GetAllpos()
        {
            using (ApplicationContext db = new ApplicationContext())
            {
                var result = db.Positions.ToList();
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

        public static string CreateSroki(string name, int coldn)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверка на сущ отдел
                bool checkIsExist = db.Sroki.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Sroki newSroki = new Sroki { Name = name, Coldn = coldn};
                    db.Sroki.Add(newSroki);
                    db.SaveChanges();
                    result = "Добавлена срочность";
                }
                return result;
            }
        }

        public static string CreateRs(int name, string email)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверка на сущ отдел
                bool checkIsExist = db.RS.Any(el => el.Email == email);
                if (!checkIsExist)
                {
                    RS newRS = new RS { Name = name, Email = email };
                    db.RS.Add(newRS);
                    db.SaveChanges();
                    result = "Добавлена РЦ";
                }
                return result;
            }
        }

        public static string CreatePos(string name)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверка на сущ отдел
                bool checkIsExist = db.Positions.Any(el => el.Name == name);
                if (!checkIsExist)
                {
                    Position newPos = new Position { Name = name};
                    db.Positions.Add(newPos);
                    db.SaveChanges();
                    result = "Добавлена должность";
                }
                return result;
            }
        }

        public static string CreateUser(string login, string pass, string fio, DateTime date_rozh, int positionId)
        {
            string result = "Уже существует";
            using (ApplicationContext db = new ApplicationContext())
            {
                //проверка на сущ отдел
                bool checkIsExist = db.Users.Any(el => el.Login == login);
                if (!checkIsExist)
                {
                    User newUser = new User { Login = login, Pass = pass, Fio = fio, Date_rozh = date_rozh, Date_create = DateTime.Now, PositionId = positionId };
                    db.Users.Add(newUser);
                    db.SaveChanges();
                    result = "Добавлена учетная запись";
                }
                return result;
            }
        }
    }
}
