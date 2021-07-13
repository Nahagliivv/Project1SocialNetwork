using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class NewsViewModel: PageViewModel
    {
        public NewsViewModel()
        {

            PostsCollection = new ObservableCollection<PostViewModel>();
            using (DataBaseContext db = new DataBaseContext())
            {
                var uCurrent = db.Users.Where(q => q.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                Name = uCurrent.Firstname + " " + uCurrent.Lastname;
                MyPageInfo = db.PageInfo.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                if (uCurrent != null && MyPageInfo != null)
                {
                    var All = db.Friends.ToList();
                    var Friends = All.Where(x => x.User1.Id == CurrentUser.CurrentUserID || x.User2.Id == CurrentUser.CurrentUserID);
                    List<long> friendsIds = new List<long>();
                    
                    foreach(var x in Friends)
                    {
                        if(x.User1.Id != CurrentUser.CurrentUserID)
                        {
                            friendsIds.Add(x.User1.Id);
                        }
                        if (x.User2.Id != CurrentUser.CurrentUserID)
                        {
                            friendsIds.Add(x.User2.Id);
                        }
                    }
                    PageInfo(db);
                    var posts = db.Posts.Where(x => x.WallID == CurrentUser.CurrentUserID);
                    List<Post> allposts = new List<Post>();
                    allposts.AddRange(posts);
                    foreach(var x in friendsIds)
                    {
                        foreach(var z in db.Posts)
                        {
                            if(x == z.WallID)
                            {
                                allposts.Add(z);
                            }
                        }
                    }
                    var sortedpost = allposts.OrderByDescending(x => x.PublicDate);
                    foreach (var x in sortedpost)
                    {
                        PostsCollection.Add(new PostViewModel(x, PostsCollection));
                    }
                    var findImg = db.Imgs.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                    LoadImg(findImg);
                    //PictureSRC = SaveAndLoadPicture.LoadImage(findImg.Data);
                    return;
                }
                else
                {
                    MessageBox.Show("Критическая ошибка базы данных");
                    App.Current.Shutdown();
                }
            }
        }
    }
}
