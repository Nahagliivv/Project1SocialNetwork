using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class FriendListViewModel: NavigateViewModel
    {
        public long UserID { get; private set; }
        public ObservableCollection<FriendBoxViewModel> FoundedUsers { get; set; }//основной список
        protected ObservableCollection<FriendBoxViewModel> PreFoundedUsers { get; set; }//список из которого уже будут отбиравться по имени и добавляься в основной список
        private string _Search { get; set; }
        public static List<long> FriendsIds;
        private Regex checkReg; //регулярка для отбора нужных пользователей в соответствии с введённой строкой
        public string SearchText { get { return _Search; } set { _Search = value; OnPropertyChanged("SearchText");  } }  //строка поиска
        private string _NotHaveAFriends { get; set; }
        public string NotHaveAFriends { get { return _NotHaveAFriends; } set { _NotHaveAFriends = value;OnPropertyChanged("NotHaveAFriends"); } } //строка, показывающая инфу, когда пользователей в списке нет
        private Visibility _FrstatusVis { get; set; } = Visibility.Collapsed;
        public int FriendsCount { get; set; }
        public Visibility FrstatusVis { get { return _FrstatusVis; } set { _FrstatusVis = value; OnPropertyChanged("FrstatusVis"); } } //Видимость строки, описанной выше
        public FriendListViewModel()
        {
            Construct();
        }
        public void Construct()
        {
           
            SearchText = "";
            FriendsIds = new List<long>();
            FoundedUsers = new ObservableCollection<FriendBoxViewModel>();
            PreFoundedUsers = new ObservableCollection<FriendBoxViewModel>();
            SearchFriends();
            SortUsers();
            CheckStatus();
        }
        public ICommand Search
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { SearchFriends(); SortUsers(); CheckStatus(); }
                });
            }
        }
        public virtual void SearchFriends() //поиск других пользователей
        {
            FoundedUsers.Clear();
            using (DataBaseContext db = new DataBaseContext())
            {
                    FriendsCount = db.Friends.Count(x => x.User1.Id == CurrentUser.CurrentUserID || x.User2.Id == CurrentUser.CurrentUserID);
                    var fr = db.Friends.ToList();
                    var Friends = fr.Where(x => x.User1.Id == CurrentUser.CurrentUserID || x.User2.Id == CurrentUser.CurrentUserID);
                    var frRequests = db.FriendsRequests.ToList();
                    var currentUserReceiever = frRequests.Where(x => x.RecieverUser.Id == CurrentUser.CurrentUserID);
                    foreach(var x in currentUserReceiever)
                    {
                    FriendsIds.Add(x.SenderUser.Id);
                     }
                    foreach(var x in Friends)
                    {
                        if(x.User1.Id != CurrentUser.CurrentUserID)
                        {
                        FriendsIds.Add(x.User1.Id);
                        continue;
                        }
                        if (x.User2.Id != CurrentUser.CurrentUserID)
                        {
                        FriendsIds.Add(x.User2.Id);
                        continue;
                        }
                     }
                   
                foreach (var z in FriendsIds)
                {
                    foreach (var x in db.Users)
                    {
                        if (z == x.Id)
                        {
                            PreFoundedUsers.Add(new FriendBoxViewModel(x));
                            break;
                        }
                    }
                    if (PreFoundedUsers.Count == FriendsCount) { break; }
                }
            }
        }
         void SortUsers() //поиск по имени, регистр не играет роли, т.к. используется .ToLower()
        {
            List<FriendBoxViewModel> preprelist = new List<FriendBoxViewModel>();
            checkReg = new Regex(SearchText.ToLower());
            foreach(var x in PreFoundedUsers)
            {
                if (checkReg.IsMatch(x.UserName.ToLower()))
                {
                    preprelist.Add(x);
                }
            }
            var sort = preprelist.OrderBy(z => z.StatusPriority);
            foreach(var x in sort)
            {
                FoundedUsers.Add(x);
            }
            PreFoundedUsers.Clear();
        }
        void CheckStatus() //наличие уведомления (тут всё понятно)
        {
            if (FoundedUsers.Count == 0 && SearchText == "")
            {
                FrstatusVis = Visibility.Visible;
                NotHaveAFriends = "У вас пока нет друзей ):";
                return;
            }
            if (FoundedUsers.Count == 0)
            {
                FrstatusVis = Visibility.Visible;
                NotHaveAFriends = "Пользователей с таким именем не найдено...";
                return;
            }
            else
            {
                FrstatusVis = Visibility.Collapsed;
            }
        }
        private ICommand _pageLog; //переход на другую стр

        public ICommand AllUsers
        {
            get
            {
                if (_pageLog == null)
                {
                    _pageLog = new RelayCommand(() =>
                    {
                        Navigate("View/AllUsersView.xaml");
                    });
                }
                return _pageLog;
            }
            set { _pageLog = value; }
        }
    }
}
