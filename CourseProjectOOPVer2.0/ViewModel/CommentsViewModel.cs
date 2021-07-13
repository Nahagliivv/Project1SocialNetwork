using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class CommentsViewModel: ViewModelBase
    {
        PostViewModel DependencyPost { get; set; }
        public ObservableCollection<PostViewModel> CurrentPost { get; set; }
        public ObservableCollection<Comment> CurrentComments { get; set; }
        public string Textt { get { return _Textt; } set { _Textt = value; OnPropertyChanged("Textt"); } }
        private string _Textt { get; set; }
        public CommentsViewModel(PostViewModel PostView)
        {
            CurrentPost = new ObservableCollection<PostViewModel>
            {
                PostView
            };
            DependencyPost = PostView;
            CurrentComments = new ObservableCollection<Comment>();
            using(DataBaseContext db = new DataBaseContext())
            {
                var _currentcomments = db.Comments.Where(x => x.Post_Id == DependencyPost.Post.Id);
                if (_currentcomments != null)
                {
                    foreach (var x in _currentcomments)
                    {
                        CurrentComments.Add(x);
                    }
                }
            }
        }
        public ICommand CreateComment
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { _CreateComment(); }
                });
            }
        }
        void _CreateComment()
        {
            if(Textt == null || Textt == "") { return; }
            Comment comment = new Comment() { Post_Id = DependencyPost.Post.Id, 
                PublicDate = DateTime.Now, Text = Textt, User_Id = CurrentUser.CurrentUserID, 
                UserFullName = CurrentUser.Current.Firstname + " " + CurrentUser.Current.Lastname };
            using(DataBaseContext db = new DataBaseContext())
            {
                db.Comments.Add(comment);
                db.SaveChanges();
            }
            Textt = "";
            DependencyPost.CountOfComments++;
            CurrentComments.Add(comment);
        }
    }
}
