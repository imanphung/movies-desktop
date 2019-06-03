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
            if (String.IsNullOrEmpty(txtPassword.Password))
            {

            }
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


        }

        private void Wizard_Finish(object sender, Xceed.Wpf.Toolkit.Core.CancelRoutedEventArgs e)
        {
            if (radBasic.IsChecked == true)
            {
                MessageBox.Show("Basic");
            }
            else if (radStandard.IsChecked == true)
            {
                MessageBox.Show("Standard");
            }
            else
            {
                MessageBox.Show("Premium");
            }
        }

        private void txtFirstName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtLastName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtCardNumber_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtExpirationDate_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void txtSecurityCode_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
