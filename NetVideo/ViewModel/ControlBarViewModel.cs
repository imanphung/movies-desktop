using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetVideo.ViewModel
{
    public class ControlBarViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand CusInfoCommand { get; set; }
        public ICommand ChangePasswordCommand { get; set; }
        public ICommand HistoryPaymentCommand { get; set; }
        public ICommand LogoutCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        private List<VideoGenre> _MenuItems;
        public List<VideoGenre> MenuItems { get { return _MenuItems; } set { _MenuItems = value; OnPropertyChanged("MenuItems"); } }

        private string _CusName;
        public string CusName { get { return _CusName; } set { _CusName = value; OnPropertyChanged("CusName"); } }

        private string _KeyWords;
        public string KeyWords { get { return _KeyWords; } set { _KeyWords = value; OnPropertyChanged("KeyWords"); } }

        private int _IdAccount;
        public int IdAccount { get { return _IdAccount; } set { _IdAccount = value; OnPropertyChanged("IdAccount"); } }

        public ControlBarViewModel()
        {
            NetVideoEntities db = new NetVideoEntities();
            CloseCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                System.Windows.Application.Current.Shutdown();
            });

            CusInfoCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
                db = new NetVideoEntities();
                FrameworkElement wd = GetWindow(p);
                var window = wd as Window;
                if (window != null)
                {
                    CollapseAll(window);
                    CusInfoViewModel cf = new CusInfoViewModel();
                    CustomerInfo c = db.CustomerInfoes.Where(x => x.AccountId == IdAccount).FirstOrDefault();
                    if(c != null)
                    {
                        cf.Id = IdAccount;
                        cf.FirstName = c.FirstName;
                        cf.LastName = c.LastName;
                        cf.CardNumber = c.CardNumber;
                        cf.ExpirationDate = c.CardExpirationDate.ToString();
                        cf.SecurityCode = c.SecurityCode;
                    }
                    UserControl uc1 = (UserControl)wd.FindName("cusInfo");
                    uc1.DataContext = cf;
                    uc1.Visibility = Visibility.Visible;
                }
            });

            ChangePasswordCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
                FrameworkElement wd = GetWindow(p);
                var window = wd as Window;
                if (window != null)
                {
                    CollapseAll(window);
                    ChangePasswordViewModel cp = new ChangePasswordViewModel();
                    cp.IdAccount = IdAccount;
                    UserControl uc3 = (UserControl)wd.FindName("changePassword");
                    uc3.DataContext = cp;
                    uc3.Visibility = Visibility.Visible;
                }
            });

            LogoutCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement wd = GetWindow(p);
                var window = wd as Window;
                if (window != null)
                {
                    window.Close();
                }
            });

            SearchCommand = new RelayCommand<UserControl>((p) => { return true; }, (p) => {
                FrameworkElement wd = GetWindow(p);
                var window = wd as Window;
                if (window != null)
                {
                    CollapseAll(window);
                    ListVideo2ViewModel lv = new ListVideo2ViewModel();
                    lv.ListVideo = db.VideoInfoes.Where(v => v.Name.ToLower().Contains(KeyWords.ToLower())).ToList();
                    lv.TotalPage = (int)Math.Ceiling(lv.ListVideo.Count() * 1.0 / lv.PageSize);
                    lv.ListVideoShow = new ObservableCollection<VideoInfo>(lv.ListVideo.OrderBy(l => l.Id).Skip((lv.CurPage - 1) * lv.PageSize).Take(lv.PageSize).ToList());
                    
                    UserControl uc2 = (UserControl)wd.FindName("list2");
                    uc2.DataContext = lv;
                    uc2.Visibility = Visibility.Visible;
                }
            });

            MenuItems = db.VideoGenres.ToList();
        }

        FrameworkElement GetWindow(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }

        void CollapseAll(Window wd)
        {
            ScrollViewer scroll = (ScrollViewer)wd.FindName("scrollViewerMain");
            scroll.Visibility = Visibility.Collapsed;

            UserControl uc1 = (UserControl) wd.FindName("cusInfo");
            uc1.Visibility = Visibility.Collapsed;

            UserControl uc2 = (UserControl) wd.FindName("list2");
            uc2.Visibility = Visibility.Collapsed;

            UserControl uc3 = (UserControl) wd.FindName("changePassword");
            uc3.Visibility = Visibility.Collapsed;

            UserControl uc4 = (UserControl) wd.FindName("paymentHistory");
            uc4.Visibility = Visibility.Collapsed;
        }
    }
}
