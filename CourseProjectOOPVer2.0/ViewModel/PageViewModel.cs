using CourseProjectOOPVer2._0.Interfaces;
using CourseProjectOOPVer2._0.Logic;
using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using CourseProjectOOPVer2._0.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class PageViewModel: NavigateViewModel, IPageRealization
    {
        public ObservableCollection<PostViewModel> PostsCollection { get; set; }
        public Page MyPageInfo { get; set; }
        public string Name { get; set; }
        public PageViewModel()
        {

            PostsCollection = new ObservableCollection<PostViewModel>();
            using(DataBaseContext db = new DataBaseContext())
            {
                var uCurrent = db.Users.Where(q => q.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                Name = uCurrent.Firstname + " " + uCurrent.Lastname;
                MyPageInfo = db.PageInfo.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                if(uCurrent!=null&& MyPageInfo!=null)
                {
                    PageInfo(db); 
                    var posts = db.Posts.Where(x => x.WallID == CurrentUser.CurrentUserID);
                    var sortedpost = posts.OrderByDescending(x => x.PublicDate);
                    foreach(var x in sortedpost)
                    {
                        PostsCollection.Add(new PostViewModel(x,PostsCollection));
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
        public void PageInfo(DataBaseContext db) //Вывод инфы о пользователе на страницу
        {
            MyPageInfo = db.PageInfo.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
            if (MyPageInfo.Sex == null || MyPageInfo.Sex == "") { SexVis = Visibility.Collapsed; }
            if (MyPageInfo.BirthDay == null) { DateVis = Visibility.Collapsed; }
            if (MyPageInfo.Country == null || MyPageInfo.Country == "") { CountryVis = Visibility.Collapsed; }
            if (MyPageInfo.City == null || MyPageInfo.City == "") { CityVis = Visibility.Collapsed; }
            if (MyPageInfo.AboutMyself == null || MyPageInfo.AboutMyself == "") { AboutVis = Visibility.Collapsed; }
        }
        public void LoadImg(Img pic) //////преобразование бит в картинку
        {
            if (pic != null)
            {
                PictureSRC = SaveAndLoadPicture.LoadImage(pic.Data);

            }

        }
        public void CreatePost() //окно создания поста
        {
            CreatePostView create = new CreatePostView(this);
            System.Windows.Media.Effects.BlurEffect objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 4;
            App.Current.MainWindow.Effect = objBlur;
            create.ShowDialog();
            App.Current.MainWindow.Effect = null;

        }
        public void EdWnd() ///окно редактирования
        {
            EditWindow wnd = new EditWindow();
            wnd.DataContext = new EditViewModel(MyPageInfo, wnd,this);
            System.Windows.Media.Effects.BlurEffect objBlur = new System.Windows.Media.Effects.BlurEffect();
            objBlur.Radius = 4;
            App.Current.MainWindow.Effect = objBlur;
            wnd.ShowDialog();
            App.Current.MainWindow.Effect = null;
        }
        public string Sex
        {
            get { return MyPageInfo.Sex; }
            set
            {
                MyPageInfo.Sex = value;
                OnPropertyChanged("Sex");
            }
        }
        public DateTime? BirthDay
        {
            get { return MyPageInfo.BirthDay; }
            set
            {
                MyPageInfo.BirthDay = value;
                OnPropertyChanged("BirthDay");
            }
        }
        public string Country
        {
            get { return MyPageInfo.Country; }
            set
            {
                MyPageInfo.Country = value;
                OnPropertyChanged("Country");
            }
        }
        public string City
        {
            get { return MyPageInfo.City; }
            set
            {
                MyPageInfo.City = value;
                OnPropertyChanged("City");
            }
        }
        public string AboutMyself
        {
            get { return MyPageInfo.AboutMyself; }
            set
            {
                MyPageInfo.AboutMyself = value;
                OnPropertyChanged("AboutMyself");
            }
        }
        public ICommand Edit
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { EdWnd(); }
                });
            }
        }
        private ImageSource Pic { get; set; }
        public ImageSource PictureSRC
        {
            get { return Pic; }
            set
            {
                Pic = value;
                OnPropertyChanged("PictureSRC");
            }
        }
        private Visibility SexVis1 { get; set; } = Visibility.Visible;
        public Visibility SexVis
        {
            get { return SexVis1; }
            set
            {
                SexVis1 = value;
                OnPropertyChanged("SexVis");
            }
        }
        private Visibility DateVis1 { get; set; } = Visibility.Visible;
        public Visibility DateVis
        {
            get { return DateVis1; }
            set
            {
                DateVis1 = value;
                OnPropertyChanged("DateVis");
            }
        }
        private Visibility CountryVis1 { get; set; } = Visibility.Visible;
        public Visibility CountryVis
        {
            get { return CountryVis1; }
            set
            {
                CountryVis1 = value;
                OnPropertyChanged("CountryVis");
            }
        }
        private Visibility CityVis1 { get; set; } = Visibility.Visible;
        public Visibility CityVis
        {
            get { return CityVis1; }
            set
            {
                CityVis1 = value;
                OnPropertyChanged("CityVis");
            }
        }
        public Visibility AboutVis1 { get; set; } = Visibility.Visible;
        public Visibility AboutVis
        {
            get { return AboutVis1; }
            set
            {
                AboutVis1 = value;
                OnPropertyChanged("AboutVis");
            }
        }
        public ICommand NewPost
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { CreatePost(); }
                });
            }
        }
        ~PageViewModel()
        {
            PictureSRC = null;
            Pic = null;
           // Debug.WriteLine("Вызван деструктор");
        }
    }
}
