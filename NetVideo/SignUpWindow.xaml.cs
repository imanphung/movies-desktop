using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using NetVideo.ViewModel;

namespace NetVideo
{
    /// <summary>
    /// Interaction logic for SignUpWindow.xaml
    /// </summary>
    public partial class SignUpWindow : Window
    {
        public SignUpWindow()
        {
            InitializeComponent();
            SignUpViewModel su = new SignUpViewModel();
            this.DataContext = su;
        }

       
        void SetSelectedNextPage1()
        {
            if (txtPassword.Password.Count() > 1 && txtEmail.Text.Count() > 1)
            {
                if ((!Validation.GetHasError(txtEmail) && !Validation.GetHasError(txtPassword)) || (!Validation.GetHasError(txtEmail) && txtPassword.Password.Count() == 4))
                {
                    Page1.CanSelectNextPage = true;
                }
                else
                {
                    Page1.CanSelectNextPage = false;
                }
            }
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetSelectedNextPage1();
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
        {
            SetSelectedNextPage1();
        }

        void SetSelectedNextPage2()
        {
            string fisrtName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string cardNumber = txtCardNumber.Text;
            string expirationDate = txtExpirationDate.Text;
            string securityCode = txtSecurityCode.Text;

            if (fisrtName.Count() > 1 && lastName.Count() > 1 && cardNumber.Count() > 1 && expirationDate.Count() > 1 && securityCode.Count() > 1)
            {
                if ((!Validation.GetHasError(txtFirstName) && !Validation.GetHasError(txtLastName) && !Validation.GetHasError(txtCardNumber) && !Validation.GetHasError(txtExpirationDate) && !Validation.GetHasError(txtSecurityCode)))
                {
                    Page2.CanSelectNextPage = true;
                }
                else
                {
                    Page2.CanSelectNextPage = false;
                }
            }
        }

        private void Wizard_Finish(object sender, Xceed.Wpf.Toolkit.Core.CancelRoutedEventArgs e)
        {
            NetVideoEntities db = new NetVideoEntities();
            int levelID = 3;

            if (radBasic.IsChecked == true)
            {
                levelID = 1;
            }
            else if (radStandard.IsChecked == true)
            {
                levelID = 2;
            }

            Account acc = new Account();
            acc.Email = txtEmail.Text;
            acc.Password = CreateMD5(Base64Encode(txtPassword.Password));
            acc.LevelId = levelID;
            acc.ActivationDate = DateTime.Now.Date;
            acc.ExpirationDate = DateTime.Now.Date.AddDays(30);
            db.Accounts.Add(acc);

            CustomerInfo cus = new CustomerInfo();
            cus.FirstName = txtFirstName.Text;
            cus.LastName = txtLastName.Text;
            cus.AccountId = acc.Id;
            cus.CardNumber = txtCardNumber.Text;
            string exDate = txtExpirationDate.Text;
            string[] split = exDate.Split('/');
            int month = int.Parse(split[0]);
            int year = int.Parse(split[1]) + 2000;
            DateTime date = new DateTime(year, month, 1);
            cus.CardExpirationDate = date;
            cus.SecurityCode = txtSecurityCode.Text;
            db.CustomerInfoes.Add(cus);

            db.SaveChanges();
            MessageBox.Show("Success!");
        }

        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetSelectedNextPage2();
        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetSelectedNextPage2();
        }

        private void txtCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetSelectedNextPage2();
        }

        private void txtExpirationDate_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetSelectedNextPage2();
        }

        private void txtSecurityCode_TextChanged(object sender, TextChangedEventArgs e)
        {
            SetSelectedNextPage2();
        }
    }
}
