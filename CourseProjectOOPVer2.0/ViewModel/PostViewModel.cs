using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using CourseProjectOOPVer2._0.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using CourseProjectOOPVer2._0.Interfaces;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class PostViewModel: ViewModelBase, IPostRealization
    {
        private ObservableCollection<PostViewModel> ParentListThis { get; set; }
        public Post Post { get; set; }
        public string Text { get; set; } //текст поста
        public string UserFullName { get; set; }// полное имя пользователя
        public DateTime PublicDate { get; set; }//дата публикации
        private int LikesCount { get; set; }
        private Visibility _DestroyAPostVis { get; set; } = Visibility.Collapsed; //возможность удаления окна
        public Visibility DestroyAPostVis
        {
            get { return _DestroyAPostVis; }
            set
            {
                _DestroyAPostVis = value;
                OnPropertyChanged("DestroyAPostVis");
            }
        }
        public int LikesNumber ///кол-во лайков
        {
            get { return LikesCount; }
            set
            {
                LikesCount = value;
                OnPropertyChanged("LikesNumber");
            }
        }
        private ImageSource Img { get; set; }
        int IsLike;
        public ImageSource LikeStatus ///сердечко
        {
            get { return Img; }
            set
            {
                Img = value;
                OnPropertyChanged("LikeStatus");
            }
        }
        private long _CountOfComments { get; set; }
        public long CountOfComments ///сердечко
        {
            get { return _CountOfComments; }
            set
            {
                _CountOfComments = value;
                OnPropertyChanged("CountOfComments");
            }
        }
        public PostViewModel(Post Post, ObservableCollection<PostViewModel> ParentList)
        {
            ParentListThis = ParentList;
            if (Post.WallID == CurrentUser.CurrentUserID)
            {
                DestroyAPostVis = Visibility.Visible;
            }
            this.Post = Post;
            Text = Post.Text;
            UserFullName = Post.UserFullName;
            PublicDate = Post.PublicDate;
            using(DataBaseContext db = new DataBaseContext())
            {
                CountOfComments = db.Comments.Count(x => x.Post_Id == Post.Id);
            }
            CheckAlike();
        }
        public ICommand Like
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { SetLike(); }
                });
            }
        }
        public ICommand Comments
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { ShowComments(); }
                });
            }
        }
        void ShowComments()
        {
            CommentWindow create = new CommentWindow(this);
            System.Windows.Media.Effects.BlurEffect objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 4;
            App.Current.MainWindow.Effect = objBlur;
            create.ShowDialog();
            App.Current.MainWindow.Effect = null;
        }
        public void CheckAlike()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                LikesNumber = db.Likes.Count(x => x.Post_ID == Post.Id);
                IsLike = db.Likes.Count(x => x.Post_ID == Post.Id && x.User_ID == CurrentUser.CurrentUserID);
                if (IsLike == 0)
                {
                    LikeStatus = (new ImageSourceConverter()).ConvertFromString(@"pack://application:,,,/styles/IcnsPic/Like.png") as ImageSource;
                    return;
                }
                if (IsLike == 1)
                {
                    LikeStatus = (new ImageSourceConverter()).ConvertFromString(@"pack://application:,,,/styles/IcnsPic/LikeBlack.png") as ImageSource;
                    return;
                }
                else { MessageBox.Show("Проблема с бд..."); }
            }
        }
        public void SetLike()
        {
            if(IsLike == 0)
            {
                using(DataBaseContext db = new DataBaseContext())
                {
                    db.Likes.Add(new Like() { Post_ID = Post.Id, User_ID = CurrentUser.CurrentUserID });
                    db.SaveChanges();
                }
                LikeStatus = (new ImageSourceConverter()).ConvertFromString(@"pack://application:,,,/styles/IcnsPic/LikeBlack.png") as ImageSource;
                IsLike = 1;
                LikesNumber += 1;
                return;
            }
            if(IsLike == 1)
            {
                using(DataBaseContext db = new DataBaseContext())
                {
                    var like = db.Likes.Where(x => x.Post_ID == Post.Id && x.User_ID == CurrentUser.CurrentUserID).FirstOrDefault();
                    db.Likes.Remove(like);
                    db.SaveChanges();
                }
                LikeStatus = (new ImageSourceConverter()).ConvertFromString(@"pack://application:,,,/styles/IcnsPic/Like.png") as ImageSource;
                IsLike = 0;
                LikesNumber -= 1;
                return;
            }
        }

        public ICommand DelPost/////////////удаление поста
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { DeleteAPost(); }
                });
            }
        }
        void DeleteAPost()
        {
            var accept = MessageBox.Show("Вы действительно хотите удалить пост без возможности восстановления?","Удаление поста", MessageBoxButton.YesNo);
            if(accept != MessageBoxResult.Yes)
            {
                return;
            }
            ParentListThis.Remove(this);
            using(DataBaseContext db = new DataBaseContext())
            {
                foreach(var x in db.Comments)
                {
                    if(x.Post_Id == Post.Id)
                    {
                        db.Comments.Remove(x);
                    }
                }
                foreach (var x in db.Likes)
                {
                    if (x.Post_ID == Post.Id)
                    {
                        db.Likes.Remove(x);
                    }
                }
                db.Posts.Remove(db.Posts.Where(x=>x.Id==Post.Id).FirstOrDefault());
                db.SaveChanges();
            }
        }
    }
}
