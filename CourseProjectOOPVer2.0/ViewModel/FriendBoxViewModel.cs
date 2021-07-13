using CourseProjectOOPVer2._0.Logic;
using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class FriendBoxViewModel: ViewModelBase
    {
        public User user { get; private set; }
        public string UserName { get; set; }
        public ImageSource ImageSource { get; set; }
        public string FriendStatus { get; set; }
        public byte StatusPriority { get; }
        public FriendBoxViewModel(User user)
        {
            this.user = user;
            using (DataBaseContext db = new DataBaseContext())
            {
                var Image = db.Imgs.Where(x => x.Id == user.Id).FirstOrDefault();
                ImageSource = SaveAndLoadPicture.LoadImage(Image.Data);
                var iffriends = db.Friends.Count(x => x.User1.Id == CurrentUser.CurrentUserID && x.User2.Id == user.Id || x.User2.Id == CurrentUser.CurrentUserID && x.User1.Id == user.Id);
                var iffriendrequest = db.FriendsRequests.Count(x => x.RecieverUser.Id == CurrentUser.CurrentUserID && x.SenderUser.Id == user.Id );
                var iffriendrequest2 = db.FriendsRequests.Count(x => x.SenderUser.Id == CurrentUser.CurrentUserID && x.RecieverUser.Id == user.Id);
                UserName = user.Firstname + " " + user.Lastname;
                if (iffriendrequest2 == 1)
                {
                    StatusPriority = 2;
                    FriendStatus = "Запрос на дружбу отправлен";
                    return;
                }
                if (iffriendrequest == 1)
                {
                    StatusPriority = 0;
                    FriendStatus = "В ожидании ответа на дружбу";
                    return;
                }
                if (iffriends == 0)
                {
                    StatusPriority = 3;
                    FriendStatus = "не друзья";
                    return;
                }
                if (iffriends == 1)
                {
                    StatusPriority = 1;
                    FriendStatus = "друзья";
                    return;
                }
                else
                {
                    MessageBox.Show("Ого, ошибка, проверь таблицу друзей в бд...");
                }
                
            }
        }
        public ICommand OpenUser
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { _OpenUser(); }
                });
            }
        }
        void _OpenUser()
        {
            CurrentUser.MasterRef.SlowOpacity(new View.FriendPageView(user));
        }
    }
}
