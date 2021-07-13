using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class AllUsersVIewModel: FriendListViewModel
    {
        public string NotFound { get; set; } = "Пользователей с таким именем не найдено"; 
        public AllUsersVIewModel()
        {
            SearchFriends();
            Sort();
        }
        public new ICommand Search
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { SearchFriends(); Sort(); }
                });
            }
        }
        public override void SearchFriends()
        {
            PreFoundedUsers.Clear();
            FoundedUsers.Clear();
            using (var db = new Model.DB.DataBaseContext())
            {
                if (FriendsCount != 0)
                {
                    foreach (var z in db.Users)
                    {
                            PreFoundedUsers.Add(new FriendBoxViewModel(z));     
                    }
                    return;
                }
                foreach (var z in db.Users)
                {
                if(z.Id!= Model.CurrentUser.CurrentUserID)
                 PreFoundedUsers.Add(new FriendBoxViewModel(z));
                }
            }
        }
        private void Sort()
        {
            var reg = new Regex(SearchText.ToLower());
            foreach(var x in PreFoundedUsers)
            {
                if (reg.IsMatch(x.UserName.ToLower()) && x.StatusPriority!=1 && x.user.IsActivate)
                {
                    FoundedUsers.Add(x);
                }
            }
            if(FoundedUsers.Count == 0)
            {
                FrstatusVis = System.Windows.Visibility.Visible;
                return;
            }
            if(FoundedUsers.Count > 0)
            {
                FrstatusVis = System.Windows.Visibility.Hidden;
                return;
            }
        }
    }
}
