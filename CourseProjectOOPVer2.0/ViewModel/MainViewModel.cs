using GalaSoft.MvvmLight;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        public ICommand ShDw
        {
            get
            {
                return new DelegateCommand(() =>
                {
                     ShutDown();
                });
            }
        }
        void ShutDown()
        {
            App.Current.Shutdown();
        }
        public ICommand Min
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Minimize();
                });
            }
        }
        void Minimize()
        {
            App.Current.MainWindow.WindowState = System.Windows.WindowState.Minimized;
        }
        public MainViewModel()
        {

        }
    }
}