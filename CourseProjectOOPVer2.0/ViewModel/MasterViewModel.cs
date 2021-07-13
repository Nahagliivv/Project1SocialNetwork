using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class MasterViewModel : ViewModelBase
    {
        public Page _currentpage;
        //private Page Mypage;
        //private Page FrList;
        private Visibility _CounFriendRequestsVis { get; set; } = Visibility.Hidden;
        public Visibility CountFriendRequestsVis { get { return _CounFriendRequestsVis; } set { _CounFriendRequestsVis = value; OnPropertyChanged("CountFriendRequestsVis"); } }
        private long _CounFriendRequests { get; set; }
        public long CountFriendRequests { get { return _CounFriendRequests; } set { _CounFriendRequests = value; OnPropertyChanged("CountFriendRequests"); } }
        public Page CurrentPage { get { return _currentpage; } set { _currentpage = value; OnPropertyChanged("CurrentPage"); } }
        private double _frameOpacity;
        public double FrameOpacity { get { return _frameOpacity; } set { _frameOpacity = value; OnPropertyChanged("FrameOpacity"); } }
        public async void SlowOpacity(Page page)
        {
            await Task.Factory.StartNew(() =>
            {
                for (double i = 1.0; i > 0.0; i -= 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
                CurrentPage = page;
                for (double i = 0.0; i < 1.1; i += 0.1)
                {
                    FrameOpacity = i;
                    Thread.Sleep(10);
                }
            });
        }
        public MasterViewModel()
        {
            UpdateNotifications();
            Model.CurrentUser.MasterRef = this;
            CurrentPage = new View.MyPagePage();
            //Mypage = new View.MyPagePage();
            //FrList = new View.FriendListView();
            //CurrentPage = Mypage;
            FrameOpacity = 1;
        }
        void UpdateNotifications()
        {
            using (var db = new DataBaseContext())
            {
                CountFriendRequests = db.FriendsRequests.Count(x => x.RecieverUser.Id == Model.CurrentUser.CurrentUserID);
                if (CountFriendRequests != 0)
                {
                    CountFriendRequestsVis = Visibility.Visible;
                    return;
                }
                if (CountFriendRequests == 0)
                {
                    CountFriendRequestsVis = Visibility.Hidden;
                    //TODO: фигово считает проверь
                    return;
                }

            }
        }
        public ICommand Home //на страницу текущего пользователя
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _Home();
                });
            }
        }

        public ICommand OpenNews //на страницу текущего пользователя
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    News();
                });
            }
        }
        void News()
        {
            Logic.ClearJournal.CleanJournal();
            UpdateNotifications();
            SlowOpacity(new View.NewsView());
        }

        void _Home()
        {
            // GC.Collect(10, GCCollectionMode.Forced);
            UpdateNotifications();
            Logic.ClearJournal.CleanJournal();
            SlowOpacity(new View.MyPagePage());
           
        }
        public ICommand FriendList //на страницу текущего пользователя
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _FriendList();
                });
            }
        }
        void _FriendList()
        {
            UpdateNotifications();
            //GC.Collect(0, GCCollectionMode.Forced);
            Logic.ClearJournal.CleanJournal();
            SlowOpacity(new View.FriendListView());
           
        }
        public ICommand MessageList 
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _MessageList();
                });
            }
        }
        void _MessageList()
        {
            UpdateNotifications();
            // GC.Collect(10, GCCollectionMode.Forced);
            Logic.ClearJournal.CleanJournal();
            SlowOpacity(new View.MessageListView());
            
        } //список собщений
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
        public ICommand Exit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    Ex();
                });
            }
        }
        void Ex()
        {
            using (var fs = new FileStream(@"SavedUser/User.txt", FileMode.Truncate))
            {
            }
            App.Current.MainWindow.Hide();
            App.Current.MainWindow = new MainWindow();
            App.Current.MainWindow.Show();
        }
    }
}
