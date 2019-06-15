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

namespace NetVideo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            NetVideoEntities db = new NetVideoEntities();
            List<VideoInfo> l = db.VideoInfoes.ToList();

            ListVideoViewModel lvMyList = new ListVideoViewModel();
            lvMyList.TitleList = "My list";
            lvMyList.List = new ObservableCollection<VideoInfo>(l);
            listMyList.DataContext = lvMyList;

            ListVideoViewModel lvTrending = new ListVideoViewModel();
            lvTrending.TitleList = "Trending now";
            lvTrending.List = new ObservableCollection<VideoInfo>(l.Where(p => p.HotLevel == 2).ToList());
            listTrending.DataContext = lvTrending;

            var minValue = db.VideoInfoes.Min(x => x.HotLevel);
            VideoInfo v = db.VideoInfoes.Where(x => x.HotLevel == minValue).FirstOrDefault();
            DetailVideoViewModel d = new DetailVideoViewModel();
            d.BindingDetail(v.Id, videoHot);

            ListVideo2ViewModel lv2 = new ListVideo2ViewModel();
            list2.DataContext = lv2;
        }

        public ControlBarViewModel controlBarVM { get; set; }
        public MainWindow(int id)
        {
            InitializeComponent();
            NetVideoEntities db = new NetVideoEntities();

            CustomerInfo cus = db.CustomerInfoes.FirstOrDefault(c => c.AccountId == id);
            controlBarVM = new ControlBarViewModel();
            controlBarVM.CusName = cus.FirstName + " " + cus.LastName;
            controlBarVM.IdAccount = id;
            controlBarMain.DataContext = controlBarVM;

            List<VideoInfo> l = db.VideoInfoes.ToList();

            ListVideoViewModel lvMyList = new ListVideoViewModel();
            lvMyList.TitleList = "My list";
            lvMyList.List = new ObservableCollection<VideoInfo>(l);
            listMyList.DataContext = lvMyList;

            ListVideoViewModel lvTrending = new ListVideoViewModel();
            lvTrending.TitleList = "Trending now";
            lvTrending.List = new ObservableCollection<VideoInfo>(l.Where(p => p.HotLevel == 2).ToList());
            listTrending.DataContext = lvTrending;

            var minValue = db.VideoInfoes.Min(x => x.HotLevel);
            VideoInfo v = db.VideoInfoes.Where(x => x.HotLevel == minValue).FirstOrDefault();
            DetailVideoViewModel d = new DetailVideoViewModel();
            d.BindingDetail(v.Id, videoHot);
        }
    }
}
