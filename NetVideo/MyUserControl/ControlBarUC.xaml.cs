using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NetVideo.ViewModel;

namespace NetVideo.MyUserControl
{
    /// <summary>
    /// Interaction logic for ControlBarUC.xaml
    /// </summary>
    public partial class ControlBarUC : UserControl
    {
        public ControlBarViewModel Viewmodel { get; set; }
        public ControlBarUC()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = sender as Button;
            int genreId = int.Parse(btn.Tag.ToString());
            Window wd = GetWindow();
            CollapseAll(wd);

            NetVideoEntities db = new NetVideoEntities();
            ListVideo2ViewModel lv = new ListVideo2ViewModel();
            lv.ListVideo = db.VideoInfoes.Where(x => x.VideoGenres.Select(z => z.Id).Contains(genreId)).ToList();
            lv.TotalPage = (int)Math.Ceiling(lv.ListVideo.Count() * 1.0 / lv.PageSize);
            lv.ListVideoShow = new ObservableCollection<VideoInfo>(lv.ListVideo.OrderBy(l => l.Id).Skip((lv.CurPage - 1) * lv.PageSize).Take(lv.PageSize).ToList());

            UserControl uc2 = (UserControl)wd.FindName("list2");
            uc2.DataContext = lv;
            uc2.Visibility = Visibility.Visible;

        }

        Window GetWindow()
        {
            FrameworkElement parent = this;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return (Window)parent;
        }

        void CollapseAll(Window wd)
        {
            ScrollViewer scroll = (ScrollViewer)wd.FindName("scrollViewerMain");
            scroll.Visibility = Visibility.Collapsed;

            UserControl uc1 = (UserControl)wd.FindName("cusInfo");
            uc1.Visibility = Visibility.Collapsed;

            UserControl uc2 = (UserControl)wd.FindName("list2");
            uc2.Visibility = Visibility.Collapsed;

            UserControl uc3 = (UserControl)wd.FindName("changePassword");
            uc3.Visibility = Visibility.Collapsed;

            UserControl uc4 = (UserControl)wd.FindName("paymentHistory");
            uc4.Visibility = Visibility.Collapsed;
        }

        private void BtnHome_Click(object sender, RoutedEventArgs e)
        {
            Window wd = GetWindow();
            CollapseAll(wd);
            ScrollViewer scroll = (ScrollViewer)wd.FindName("scrollViewerMain");
            scroll.Visibility = Visibility.Visible;
        }

        private void BtnMyList_Click(object sender, RoutedEventArgs e)
        {
            Window wd = GetWindow();
            CollapseAll(wd);
            int idAccount = int.Parse((sender as Button).Tag.ToString());

            NetVideoEntities db = new NetVideoEntities();
            ListVideo2ViewModel lv = new ListVideo2ViewModel();
            lv.ListVideo = db.VideoInfoes.Where(x => x.Accounts.Select(z => z.Id).Contains(idAccount)).ToList();
            lv.TotalPage = (int)Math.Ceiling(lv.ListVideo.Count() * 1.0 / lv.PageSize);
            lv.ListVideoShow = new ObservableCollection<VideoInfo>(lv.ListVideo.OrderBy(l => l.Id).Skip((lv.CurPage - 1) * lv.PageSize).Take(lv.PageSize).ToList());

            UserControl uc2 = (UserControl)wd.FindName("list2");
            uc2.DataContext = lv;
            uc2.Visibility = Visibility.Visible;
        }

        private void BtnHome_MouseEnter(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = Brushes.LightGray;
        }

        private void BtnHome_MouseLeave(object sender, MouseEventArgs e)
        {
            (sender as Button).Background = Brushes.Transparent;
        }
    }
}
