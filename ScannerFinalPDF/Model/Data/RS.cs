using ScannerFinalPDF.Model.ViewModel;

namespace ScannerFinalPDF.Model.Data
{
    public class RS 
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Email { get; set; }


        public RS() { }

        public RS(int name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
