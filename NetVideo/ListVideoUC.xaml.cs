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
using System.Windows.Navigation;
using System.Windows.Shapes;
using NetVideo.ViewModel;

namespace NetVideo
{
    /// <summary>
    /// Interaction logic for ListVideoUC.xaml
    /// </summary>
    public partial class ListVideoUC : UserControl
    {
        public ListVideoUC()
        {
            InitializeComponent();
        }

        string oldTag = null;
        private void StackPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            NetVideoEntities db = new NetVideoEntities();
            StackPanel s = sender as StackPanel;
            StackPanel stack = (StackPanel)s.FindName("stack");
            if (oldTag != null)
            {
                if (oldTag == stack.Tag.ToString())
                {
                    detail.Visibility = System.Windows.Visibility.Collapsed;
                    oldTag = null;
                    return;
                }
            }
            int id = int.Parse(stack.Tag.ToString());
            VideoInfo videoInfo = db.VideoInfoes.Where(x => x.Id == id).FirstOrDefault();
            detail.DataContext = videoInfo;
            genres g = new genres();
            g.ListGenre = videoInfo.VideoGenres.ToList();
            StackPanel tb = (StackPanel)detail.FindName("tbGenres");
            tb.DataContext = g;
            detail.Visibility = System.Windows.Visibility.Visible;
            oldTag = stack.Tag.ToString();
        }
    }

    public class genres : BaseViewModel
    {
        private List<VideoGenre> _ListGenre;
        public List<VideoGenre> ListGenre { get { return _ListGenre; } set { _ListGenre = value; OnPropertyChanged("ListGenre"); } }
    }
}
