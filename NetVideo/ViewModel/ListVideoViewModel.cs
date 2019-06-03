using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVideo.ViewModel
{
    public class ListVideoViewModel : BaseViewModel
    {
        private ObservableCollection<VideoInfo> _List;
        public ObservableCollection<VideoInfo> List { get { return _List; } set { _List = value; OnPropertyChanged("List"); } }

        private String _TitleList;
        public String TitleList { get { return _TitleList; } set { _TitleList = value; OnPropertyChanged("TitleList"); } }

        public ListVideoViewModel()
        {
            
        }
    }
}
