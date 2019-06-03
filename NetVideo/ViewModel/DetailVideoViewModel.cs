using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace NetVideo.ViewModel
{
    class DetailVideoViewModel : BaseViewModel
    {
        private List<VideoGenre> _ListGenre;
        public List<VideoGenre> ListGenre { get { return _ListGenre; } set { _ListGenre = value; OnPropertyChanged("ListGenre"); } }

        public void BindingDetail(int id, UserControl nameUC)
        {
            NetVideoEntities db = new NetVideoEntities();
            DetaiVideoUC uc = nameUC as DetaiVideoUC;
            VideoInfo videoInfo = db.VideoInfoes.Where(x => x.Id == id).FirstOrDefault();
            uc.DataContext = videoInfo;
            this.ListGenre = videoInfo.VideoGenres.ToList();
            StackPanel tb = (StackPanel)uc.FindName("tbGenres");
            tb.DataContext = this;
        }
    }
}
