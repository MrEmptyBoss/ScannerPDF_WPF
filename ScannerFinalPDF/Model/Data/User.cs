using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public int PositionId { get; set; }

        public virtual Position Position { get; set; }
        [NotMapped]
        public Position UserPosition
        {
            get
            {
                return DataWorker.GetPosId(PositionId);
            }
        }

        public DateTime Date_create { get; set; }
        public DateTime Date_rozh { get; set; }


        public User() { }
    }
}
