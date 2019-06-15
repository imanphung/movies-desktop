using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace NetVideo.ViewModel
{
    public class AdminMainWindowViewModel:BaseViewModel
    {
        public ICommand CloseCommand { get; set; }
        public ICommand DashBoardCommand { get; set; }
        public ICommand UserCommand { get; set; }
        public ICommand VideoCommand { get; set; }
        public ICommand AnalyticCommand { get; set; }

        public AdminMainWindowViewModel()
        {
            CloseCommand = new RelayCommand<object>((p) => { return true; }, (p) => {
                System.Windows.Application.Current.Shutdown();
            });
            DashBoardCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                CollapseAll(p);
                //
                UserControl uc1 = (UserControl)p.FindName("dashBoard");
                uc1.DataContext = null;// new ViwModel
                uc1.Visibility = Visibility.Visible;

            });
            UserCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                CollapseAll(p);
                UserControl uc2 = (UserControl)p.FindName("adminUser");
                uc2.DataContext = null;// new ViwModel
                uc2.Visibility = Visibility.Visible;
            });
            VideoCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                CollapseAll(p);
                UserControl uc3 = (UserControl)p.FindName("adminVideo");
                uc3.DataContext = null;// new ViwModel
                uc3.Visibility = Visibility.Visible;
            });
            AnalyticCommand = new RelayCommand<Window>((p) => { return true; }, (p) => {
                CollapseAll(p);
                UserControl uc4 = (UserControl)p.FindName("adminAnalytic");
                uc4.DataContext = null;// new ViwModel
                uc4.Visibility = Visibility.Visible;
            });
     

        }

        void CollapseAll(Window w)
        {
            UserControl uc1 = (UserControl)w.FindName("dashBoard");
            uc1.Visibility = Visibility.Collapsed;
            UserControl uc2 = (UserControl)w.FindName("adminUser");
            uc2.Visibility = Visibility.Collapsed;
            UserControl uc3 = (UserControl)w.FindName("adminVideo");
            uc3.Visibility = Visibility.Collapsed;
            UserControl uc4 = (UserControl)w.FindName("adminAnalytic");
            uc4.Visibility = Visibility.Collapsed;
  
        }
    }
}
