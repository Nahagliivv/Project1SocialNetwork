using CourseProjectOOPVer2._0.ViewModel;
using GalaSoft.MvvmLight.Messaging;
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
using System.Windows.Shapes;

namespace CourseProjectOOPVer2._0.View
{
    /// <summary>
    /// Логика взаимодействия для MasterWindow.xaml
    /// </summary>
    public partial class MasterWindow : Window
    {
        public MasterWindow()
        {
            InitializeComponent();
            DataContext = new MasterViewModel();
            Logic.ClearJournal.CurrentMainFrame = MainFrame;
            NavigationSetup();
        }
        void NavigationSetup()
        {
            Messenger.Default.Register<NavigateArgs>(this, (x) =>
            {
                MainFrame.Navigate(new Uri(x.Url, UriKind.Relative));
            });
        }
    }
}
