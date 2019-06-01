using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace NetVideo.Model
{
    public class VideoInfo : DependencyObject
    {
        public static readonly DependencyProperty TitleProperty;
        public static readonly DependencyProperty IdProperty;
        public static readonly DependencyProperty ImageProperty;
        public static readonly DependencyProperty PathProperty;
        public static readonly DependencyProperty DescriptionProperty;

        static VideoInfo()
        {
            TitleProperty = DependencyProperty.Register("Title", typeof(string), typeof(VideoInfo), new PropertyMetadata("New video"));
            IdProperty = DependencyProperty.Register("Id", typeof(string), typeof(VideoInfo), new PropertyMetadata("1"));
            ImageProperty = DependencyProperty.Register("Image", typeof(string), typeof(VideoInfo), new PropertyMetadata("Images\\1.jpg"));
            PathProperty = DependencyProperty.Register("Path", typeof(string), typeof(VideoInfo), new PropertyMetadata("C:\\Users\\User\\Downloads\\Video\video.mp4"));
            DescriptionProperty = DependencyProperty.Register("Description", typeof(string), typeof(VideoInfo), new PropertyMetadata("New description"));
        }

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public string Id
        {
            get { return (string)GetValue(IdProperty); }
            set { SetValue(IdProperty, value); }
        }

        public string Image
        {
            get { return (string)GetValue(ImageProperty); }
            set { SetValue(ImageProperty, value); }
        }

        public string Path
        {
            get { return (string)GetValue(PathProperty); }
            set { SetValue(PathProperty, value); }
        }

        public string Description
        {
            get { return (string)GetValue(DescriptionProperty); }
            set { SetValue(DescriptionProperty, value); }
        }
    }
}
