using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetVideo.ViewModel
{
    public class CusInfoViewModel : BaseViewModel
    {
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; OnPropertyChanged("Id"); } }

        private string _FirstName;
        public string FirstName { get { return _FirstName; } set { _FirstName = value; OnPropertyChanged("FirstName"); } }

        private string _LastName;
        public string LastName { get { return _LastName; } set { _LastName = value; OnPropertyChanged("LastName"); } }

        private string _CardNumber;
        public string CardNumber { get { return _CardNumber; } set { _CardNumber = value; OnPropertyChanged("CardNumber"); } }

        private string _ExpirationDate;
        public string ExpirationDate { get { return _ExpirationDate; } set { _ExpirationDate = value; OnPropertyChanged("ExpirationDate"); } }

        private string _SecurityCode;
        public string SecurityCode { get { return _SecurityCode; } set { _SecurityCode = value; OnPropertyChanged("SecurityCode"); } }

        public ICommand UpdateCommand { get; set; }

        public CusInfoViewModel()
        {
            UpdateCommand = new RelayCommand<UserControl>((p) => { return CanExecuteUpdate(p); }, (p) => {
                NetVideoEntities db = new NetVideoEntities();
                CustomerInfo cus = db.CustomerInfoes.SingleOrDefault(c => c.AccountId == Id);
                cus.FirstName = FirstName;
                cus.LastName = LastName;
                cus.CardNumber = CardNumber;
                cus.CardExpirationDate = null;//ExpirationDate;
                cus.SecurityCode = SecurityCode;
                db.SaveChanges();
                MessageBox.Show("Update successed!");
            });
        }

        bool CanExecuteUpdate(UserControl uc)
        {
            TextBox tbFirstName = (TextBox) uc.FindName("txtFirstName");
            TextBox tbLastName = (TextBox) uc.FindName("txtLastName");
            TextBox tbCardNumber = (TextBox) uc.FindName("txtCardNumber");
            TextBox tbExpirationDate = (TextBox) uc.FindName("txtExpirationDate");
            TextBox tbSecurityCode = (TextBox) uc.FindName("txtSecurityCode");

            return !Validation.GetHasError(tbFirstName) && !Validation.GetHasError(tbLastName) && !Validation.GetHasError(tbCardNumber)
                    && !Validation.GetHasError(tbExpirationDate) && !Validation.GetHasError(tbSecurityCode);
        }
    }
}
