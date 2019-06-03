using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetVideo.ViewModel
{
    public class LoginViewModel : BaseViewModel
    {
        public ICommand LoginCommand { get; set; }

        private String _Email;
        public String Email { get { return _Email; } set { _Email = value; OnPropertyChanged("Email"); } }

        private String _Password;
        public String Password { get { return _Password; } set { _Password = value; OnPropertyChanged("Password"); } }

        public LoginViewModel()
        {
            LoginCommand = new RelayCommand<Window>((p) => { return true; }, (p) => { Login(p); });
        }

        public void Login(Window p)
        {
            NetVideoEntities db = new NetVideoEntities();
            String passEncode = "";
            if (Password != null)
            {
                passEncode = CreateMD5(Base64Encode(Password));
            }
            var acc = db.Accounts.Where(x => x.Email == Email && x.Password == passEncode).FirstOrDefault();
            if (acc != null)
            {
                MainWindow main = new MainWindow(acc.Id);
                main.Show();
                p.Close();
            }
            else
            {
                MessageBox.Show("Sorry, we can't find an account with this email address. Please try again!");
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
