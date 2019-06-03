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
            Account acc = new Account();
            Page1.DataContext = acc;
            CustomerInfo ci = new CustomerInfo();
            Page2.DataContext = ci;
        }

        private void txtEmail_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (txtPassword.Password.Count() > 1 && txtEmail.Text.Count() > 1)
            {
                if (!Validation.GetHasError(txtEmail) && !Validation.GetHasError(txtPassword))
                {
                    Page1.CanSelectNextPage = true;
                }
                else
                {
                    Page1.CanSelectNextPage = false;
                }
            }
        }

        private void txtPassword_PasswordChanged(object sender, RoutedEventArgs e)
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

        private void Wizard_Finish(object sender, Xceed.Wpf.Toolkit.Core.CancelRoutedEventArgs e)
        {
            if (radMobile.IsChecked == true)
            {
                MessageBox.Show("Mobile");
            }
            else if (radBasic.IsChecked == true)
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
    }
}
