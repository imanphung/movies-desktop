using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace NetVideo.ViewModel
{
    public class ListVideo2ViewModel : BaseViewModel
    {
        private List<VideoInfo> _ListVideo;
        public List<VideoInfo> ListVideo { get { return _ListVideo; } set { _ListVideo = value; OnPropertyChanged("ListVideo"); } }

        private ObservableCollection<VideoInfo> _ListVideoShow;
        public ObservableCollection<VideoInfo> ListVideoShow { get { return _ListVideoShow; } set { _ListVideoShow = value; OnPropertyChanged("ListVideoShow"); } }

        private int _CurPage;
        public int CurPage { get { return _CurPage; } set { _CurPage = value; OnPropertyChanged("CurPage"); } }

        private int _PageSize;
        public int PageSize { get { return _PageSize; } set { _PageSize = value; OnPropertyChanged("PageSize"); } }

        private int _TotalPage;
        public int TotalPage { get { return _TotalPage; } set { _TotalPage = value; OnPropertyChanged("TotalPage"); } }

        public ICommand NextPageCommand { get; set; }
        public ICommand PreviousPageCommand { get; set; }
        public ICommand LastPageCommand { get; set; }
        public ICommand FirstPageCommand { get; set; }

        public ListVideo2ViewModel()
        {
            NetVideoEntities db = new NetVideoEntities();
            ListVideo = db.VideoInfoes.ToList();

            NextPageCommand = new RelayCommand<object>((p) => { return CurPage < TotalPage ? true : false; }, (p) => { CurPage++; ListVideoShow = new ObservableCollection<VideoInfo>(ListVideo.OrderBy(v => v.Id).Skip((CurPage - 1) * PageSize).Take(PageSize).ToList()); });
            PreviousPageCommand = new RelayCommand<object>((p) => { return CurPage > 1 ? true : false; }, (p) => { CurPage--; ListVideoShow = new ObservableCollection<VideoInfo>(ListVideo.OrderBy(v => v.Id).Skip((CurPage - 1) * PageSize).Take(PageSize).ToList()); });
            LastPageCommand = new RelayCommand<object>((p) => { return CurPage < TotalPage ? true : false; }, (p) => { CurPage = TotalPage; ListVideoShow = new ObservableCollection<VideoInfo>(ListVideo.OrderBy(v => v.Id).Skip((CurPage - 1) * PageSize).Take(PageSize).ToList()); });
            FirstPageCommand = new RelayCommand<object>((p) => { return CurPage > 1 ? true : false; }, (p) => { CurPage = 1; ListVideoShow = new ObservableCollection<VideoInfo>(ListVideo.OrderBy(v => v.Id).Skip((CurPage - 1) * PageSize).Take(PageSize).ToList()); });

            PageSize = 3;
            CurPage = 1;

            TotalPage = (int)Math.Ceiling(ListVideo.Count() * 1.0 / PageSize);
            ListVideoShow = new ObservableCollection<VideoInfo>(ListVideo.OrderBy(p => p.Id).Skip((CurPage - 1) * PageSize).Take(PageSize).ToList());
        }
    }
}
