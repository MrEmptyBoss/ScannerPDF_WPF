using ScannerFinalPDF.Model.ViewModel;

namespace ScannerFinalPDF.Model.Data
{
    public class RS : DataManagerVM
    {
        public int Id { get; set; }
        private int name;
        private string email;

        public int Name
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged(nameof(Name));
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged(nameof(Email));
            }
        }

        public RS() { }

        public RS(int name, string email)
        {
            Name = name;
            Email = email;
        }
    }
}
