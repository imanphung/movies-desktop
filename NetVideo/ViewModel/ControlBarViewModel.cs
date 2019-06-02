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
    public class ControlBarViewModel : BaseViewModel
    {
        public ICommand CloseCommand { get; set; }

        public ControlBarViewModel()
        {
            CloseCommand = new RelayCommand<UserControl>((p) => { return p == null ? false : true; }, (p) => {
                FrameworkElement wd = GetWindow(p);
                var window = wd as Window;
                if (window != null)
                {
                    window.Close();
                }
            });
        }

        FrameworkElement GetWindow(UserControl p)
        {
            FrameworkElement parent = p;
            while (parent.Parent != null)
            {
                parent = parent.Parent as FrameworkElement;
            }
            return parent;
        }
    }
}
