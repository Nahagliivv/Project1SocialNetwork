using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using CourseProjectOOPVer2._0.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class CreatePostViewModel : NavigateViewModel
    {
        private Post post;
        PageViewModel mypage;
        CreatePostView createview;
        public CreatePostViewModel(PageViewModel mypage, CreatePostView create)
        {
            this.mypage = mypage;
            createview = create;
        }
        private string Text { get; set; }
        public string PostText
        {
            get { return Text; }
            set
            {
                Text = value;
                OnPropertyChanged("PostText");
            }
        }

        public ICommand CreatePost
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { NewPost(); }
                });
            }
        }
        public void NewPost()
        {
            if(Text == null || Text == "")
            {
                return;
            }
            post = new Post();
            post.Text = Text;
            post.PublicDate = DateTime.Now;
            post.WallID = CurrentUser.CurrentUserID;
            post.UserFullName = CurrentUser.Current.Firstname + " " + CurrentUser.Current.Lastname;
            mypage.PostsCollection.Insert(0,new PostViewModel(post, mypage.PostsCollection));
            using(DataBaseContext db = new DataBaseContext())
            {
                db.Posts.Add(post);
                db.SaveChanges();
            }
            createview.Close();
        }
    }
}
