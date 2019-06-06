using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace NetVideo.MyConverter
{
    public class GenresConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            ICollection<VideoGenre> list = (ICollection<VideoGenre>)value;
            List<string> listName = new List<string>();
            for (int i = 0; i < list.Count; i++)
            {
                listName.Add(list.ElementAt(i).Name);
            }
            return String.Join(", ", listName.ToArray());
        }

        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
