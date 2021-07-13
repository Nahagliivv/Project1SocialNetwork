using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class FriendPageViewModel: PageViewModel
    { 
        private Model.User PageOwner { get; set; }
        
        public FriendPageViewModel(Model.User u)
        {
            PageOwner = u;
            PostsCollection.Clear();
            using (DataBaseContext db = new DataBaseContext())
            {
                var uCurrent = db.Users.Where(q => q.Id == u.Id).FirstOrDefault(); //поиск владельца страницы
                Name = uCurrent.Firstname + " " + uCurrent.Lastname; //Установление имени
                MyPageInfo = db.PageInfo.Where(x => x.Id == u.Id).FirstOrDefault(); //поиск информации о странице владельца
                if (uCurrent != null && MyPageInfo != null)
                {
                    //var user = db.PageInfo.Where(q => q.Id == u.Id).FirstOrDefault();
                    //MyPageInfo = user;
                    ////запись инфы на страницу
                    PageInfo(db, PageOwner);
                    var posts = db.Posts.Where(x => x.WallID == u.Id); //поиск постов пользователя
                    var sortedpost = posts.OrderByDescending(x => x.PublicDate); //сортировка постов по дате
                    foreach (var x in sortedpost) //вывод постов
                    {
                        PostsCollection.Add(new PostViewModel(x, PostsCollection));
                    }
                    var findImg = db.Imgs.Where(x => x.Id == u.Id).FirstOrDefault(); ///поиск изображения страницы
                    LoadImg(findImg);
                    CheckFriendStatus(db);
                    return;
                }
                else
                {
                    MessageBox.Show("Критическая ошибка базы данных");
                    App.Current.Shutdown();
                }
            }
        }
        void PageInfo(DataBaseContext db, Model.User u)
        {
            MyPageInfo = db.PageInfo.Where(x => x.Id == u.Id).FirstOrDefault();
            if (MyPageInfo.Sex == null || MyPageInfo.Sex == "") { SexVis = Visibility.Collapsed; }
            if (MyPageInfo.BirthDay == null) { DateVis = Visibility.Collapsed; }
            if (MyPageInfo.Country == null || MyPageInfo.Country == "") { CountryVis = Visibility.Collapsed; }
            if (MyPageInfo.City == null || MyPageInfo.City == "") { CityVis = Visibility.Collapsed; }
            if (MyPageInfo.AboutMyself == null || MyPageInfo.AboutMyself == "") { AboutVis = Visibility.Collapsed; }
        }
        private string _Friendstatus { get; set; }
        public string FriendStatus { get { return _Friendstatus; } set { _Friendstatus = value; OnPropertyChanged("Friendstatus"); } }
        private void CheckFriendStatus(DataBaseContext db) 
        {
        
                var isAFriend = db.Friends.Count(x => x.User1.Id == PageOwner.Id && x.User2.Id == Model.CurrentUser.CurrentUserID || x.User2.Id == PageOwner.Id && x.User1.Id == Model.CurrentUser.CurrentUserID); //друзья ли пользователи
                var isASender = db.FriendsRequests.Count(x => x.SenderUser.Id == Model.CurrentUser.CurrentUserID && x.RecieverUser.Id == PageOwner.Id); //является ли текущий пользователь отправителем заявки в друзья владельцу страницы
                var isAReciever = db.FriendsRequests.Count(x => x.RecieverUser.Id == Model.CurrentUser.CurrentUserID && x.SenderUser.Id == PageOwner.Id); //является ли текущий пользоваетль получателем заявки в друзья от владельца страницы
                if(isAFriend == 0 && isASender ==0 && isAReciever == 0)
                {
                    FriendStatus = "Добавить в друзья";
                    return;
                }
                if(isAFriend == 1)
                {
                    FriendStatus = "Удалить из друзей";
                    return;
                }
                if(isAReciever == 1)
                {
                    FriendStatus = "Принять заявку";
                    return;
                }
                if (isASender == 1)
                {
                    FriendStatus = "Отменить запрос";
                    return;
                }
            
        } //надпись на кнопке

        public ICommand ChangeAFriendStatus 
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    FriendStatusManagement();
                });
            }
        }
        private void FriendStatusManagement() //изменение статуса друга
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                var isAFriend = db.Friends.Count(x => x.User1.Id == PageOwner.Id && x.User2.Id == Model.CurrentUser.CurrentUserID || x.User2.Id == PageOwner.Id && x.User1.Id == Model.CurrentUser.CurrentUserID); //друзья ли пользователи
                var isASender = db.FriendsRequests.Count(x => x.SenderUser.Id == Model.CurrentUser.CurrentUserID && x.RecieverUser.Id == PageOwner.Id); //является ли текущий пользователь отправителем заявки в друзья владельцу страницы
                var isAReciever = db.FriendsRequests.Count(x => x.RecieverUser.Id == Model.CurrentUser.CurrentUserID && x.SenderUser.Id == PageOwner.Id); //является ли текущий пользоваетль получателем заявки в друзья от владельца страницы
                if (isAFriend == 0 && isASender == 0 && isAReciever == 0)
                {
                    db.FriendsRequests.Add(new Model.FriendsRequest() { RecieverUser = db.Users.Where(x => x.Id == PageOwner.Id).FirstOrDefault(), SenderUser = db.Users.Where(x=>x.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault() });;
                    db.SaveChanges();
                    FriendStatus = "Отменить запрос";
                    return;
                }
                if (isAFriend == 1)
                {
                    var accept = MessageBox.Show("Вы действительно хотите удалить пользователя из списка друзей?", "Удаление пользователя из списка друзей", MessageBoxButton.YesNo);
                    if (accept != MessageBoxResult.Yes)
                    {
                        return;
                    }
                    try
                    {
                        var del = db.Friends.Where(x => x.User1 == db.Users.Where(y => y.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault() && x.User2 == db.Users.Where(y => y.Id == PageOwner.Id).FirstOrDefault()).FirstOrDefault();
                        db.Friends.Remove(del);
                    }
                    catch
                    {
                        var del = db.Friends.Where(x => x.User2 == db.Users.Where(y => y.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault() && x.User1 == db.Users.Where(y => y.Id == PageOwner.Id).FirstOrDefault()).FirstOrDefault();
                        db.Friends.Remove(del);
                    }
                    db.SaveChanges();
                   FriendStatus = "Добавить в друзья";
                   return;
                }
                if (isAReciever == 1)
                {
                    var del = db.FriendsRequests.Where(x => x.RecieverUser == db.Users.Where(y => y.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault() && x.SenderUser == db.Users.Where(y => y.Id ==PageOwner.Id ).FirstOrDefault()).FirstOrDefault();
                    db.FriendsRequests.Remove(del);
                    // db.Friends.Add(new Model.Friends() {User1 = db.Users.Where(x => x.Id == PageOwner.Id).FirstOrDefault(), User2 = db.Users.Where(x => x.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault() }); ;
                    using (var transaction = db.Database.BeginTransaction())
                    {
                        db.Database.ExecuteSqlCommand($"Insert into Friends(User1_Id, User2_Id) Values ({Model.CurrentUser.CurrentUserID},{PageOwner.Id})");
                        db.SaveChanges();
                        transaction.Commit();
                    }
                  
                    FriendStatus = "Удалить из друзей";
                    return;
                }
                if (isASender == 1)
                {
                    var del = db.FriendsRequests.Where(x => x.RecieverUser == db.Users.Where(y => y.Id == PageOwner.Id).FirstOrDefault() && x.SenderUser == db.Users.Where(y => y.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault()).FirstOrDefault();
                    db.FriendsRequests.Remove(del);
                    db.SaveChanges();
                    FriendStatus = "Добавить в друзья";
                    return;
                }
            }
        }
        public ICommand OpenMessageStory
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    _OpenMessageStory();
                });
            }
        }
        private void _OpenMessageStory()
        {
            Model.CurrentUser.MasterRef.SlowOpacity(new View.DialogPage(PageOwner));
        }//открытие диалога
    }
}
