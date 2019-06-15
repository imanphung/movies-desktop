using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetVideo.ViewModel
{
    public class HistoryPaymentViewModel : BaseViewModel
    {
        private List<VideoGenre> _ListGenre;
        public List<VideoGenre> ListGenre { get { return _ListGenre; } set { _ListGenre = value; OnPropertyChanged("ListGenre"); } }
    }
}
