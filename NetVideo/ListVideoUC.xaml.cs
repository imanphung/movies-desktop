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
using NetVideo.Model;

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
            DataContext = new List<VideoInfo>
            {
                new VideoInfo { Image = "Images\\1.jpg", Id = "1"
                },
                new VideoInfo {Image = "Images\\2.jpg", Id = "2"
                },
                new VideoInfo {Image = "Images\\3.jpg", Id = "3"
                },
                new VideoInfo {Image = "Images\\4.jpg", Id = "4"
                },
                new VideoInfo {Image = "bg_1024x512.jpg", Id = "5"
                },
                new VideoInfo {Image = "Images\\6.jpg", Id = "6"
                },
                new VideoInfo {Image = "Images\\7.jpg", Id = "7"
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
                new VideoInfo {
                },
            };
        }

        string oldTag = null;
        private void StackPanel_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
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
            //detail.DataContext = stack.Tag.ToString();
            detail.Visibility = System.Windows.Visibility.Visible;
            oldTag = stack.Tag.ToString();
        }
    }
}
