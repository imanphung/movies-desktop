using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVideo.ViewModel
{
    public class SignUpViewModel : BaseViewModel
    {
        private String _Email;
        public String Email { get { return _Email; } set { _Email = value; OnPropertyChanged("Email"); } }

        private String _Password;
        public String Password { get { return _Password; } set { _Password = value; OnPropertyChanged("Password"); } }

        private String _FirstName;
        public String FirstName { get { return _FirstName; } set { _FirstName = value; OnPropertyChanged("_FirstName"); } }

        private String _LastName;
        public String LastName { get { return _LastName; } set { _LastName = value; OnPropertyChanged("LastName"); } }

        private String _CardNumber;
        public String CardNumber { get { return _CardNumber; } set { _CardNumber = value; OnPropertyChanged("CardNumber"); } }

        private String _ExpirationDate;
        public String ExpirationDate { get { return _ExpirationDate; } set { _ExpirationDate = value; OnPropertyChanged("ExpirationDate"); } }

        private String _SecurityCode;
        public String SecurityCode { get { return _SecurityCode; } set { _SecurityCode = value; OnPropertyChanged("SecurityCode"); } }
        
    }
}
