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
    public class ChangePasswordViewModel : BaseViewModel
    {
        private int _IdAccount;
        public int IdAccount { get { return _IdAccount; } set { _IdAccount = value; OnPropertyChanged("IdAccount"); } }

        private string _OldPassword;
        public string OldPassword { get { return _OldPassword; } set { _OldPassword = value; OnPropertyChanged("OldPassword"); } }

        private string _NewPassword;
        public string NewPassword { get { return _NewPassword; } set { _NewPassword = value; OnPropertyChanged("NewPassword"); } }

        private string _RepeatNewPassword;
        public string RepeatNewPassword { get { return _RepeatNewPassword; } set { _RepeatNewPassword = value; OnPropertyChanged("RepeatNewPassword"); } }

        public ICommand ChangePasswordCommand { get; set; }

        public ChangePasswordViewModel()
        {
            ChangePasswordCommand = new RelayCommand<UserControl>((p) => { return CanExecuteChangePassword(p); }, (p) => {
                ExecuteChangePassword();
            });
        }

        void ExecuteChangePassword()
        {
            string oldPasswordEncode = CreateMD5(Base64Encode(OldPassword));
            string newPasswordEncode = CreateMD5(Base64Encode(NewPassword));
            string repeatNewPasswordEncode = CreateMD5(Base64Encode(RepeatNewPassword));

            NetVideoEntities db = new NetVideoEntities();
            Account acc = db.Accounts.FirstOrDefault(a => a.Id == IdAccount);
            if(acc.Password != oldPasswordEncode)
            {
                MessageBox.Show("Incorrect current password!");
                return;
            }

            if(NewPassword != RepeatNewPassword)
            {
                MessageBox.Show("New password and repeat new password do not match!");
                return;
            }

            acc.Password = newPasswordEncode;
            db.SaveChanges();
            MessageBox.Show("Change password successed!");
        }

        bool CanExecuteChangePassword(UserControl uc)
        {
            PasswordBox tbOldPassword       = (PasswordBox)uc.FindName("OldPassword");
            PasswordBox tbNewPassword       = (PasswordBox)uc.FindName("NewPassword");
            PasswordBox tbRepeatNewPassword = (PasswordBox)uc.FindName("RepeatNewPassword");

            if(String.IsNullOrEmpty(tbOldPassword.Password) || String.IsNullOrEmpty(tbNewPassword.Password) || String.IsNullOrEmpty(tbRepeatNewPassword.Password))
            {
                return false;
            }
            else
            {
                if (!Validation.GetHasError(tbOldPassword) && !Validation.GetHasError(tbNewPassword) && !Validation.GetHasError(tbRepeatNewPassword))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
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
    }
}
