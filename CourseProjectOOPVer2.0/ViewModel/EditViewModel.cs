using CourseProjectOOPVer2._0.Logic;
using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using CourseProjectOOPVer2._0.View;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProjectOOPVer2._0.ViewModel
{
    class EditViewModel: ViewModelBase
    {
        private Model.Page pageCopy;
        private EditWindow ew;
        PageViewModel myPageViewModel;
        private Img img;
        private string wayToPic = null;

        public DateTime DateEnd { get; private set; }
        public DateTime DateStart { get; private set; }
        public EditViewModel(Model.Page page, EditWindow ew, PageViewModel myPageViewModel) //конструктор, ссылающий на информацию о текущей странице, на окно редактирования(( и на датаконтекст текущей страницы
        {
            var now = DateTime.Now;
            DateStart = now.AddYears(-100);
            DateEnd = now.AddYears(-15);
            this.myPageViewModel = myPageViewModel;
            pageCopy = page;
            this.ew = ew;
            //pageCopy = new MyPageInfo(page);
        }
        public ICommand EdPic ///////////редактирование картинки
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { EdWnd(); }
                });
            }
        }
        public ICommand SaveChanges
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { Save(); }
                });
            }
        }
        public void Save()
        {
            if (wayToPic != null)
            {
                try //если путь к изображению неправильный, будет устанавливаться предыдущая картинка
                {
                    img.Data = SaveAndLoadPicture.PictureToByte(wayToPic);
                }
                catch
                {
                    using(DataBaseContext db= new DataBaseContext())
                    {
                        var sql = db.Imgs.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                        img.Data = sql.Data;   
                    }
                }
                using (DataBaseContext db = new DataBaseContext())
                {
                        var linq = db.Imgs.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                        linq.Data = img.Data;
                        db.SaveChanges();
                }
            }
         
            using (DataBaseContext db = new DataBaseContext())//сохранение изменений страницы в бд
            {
                var linq = db.PageInfo.Where(x => x.Id == CurrentUser.CurrentUserID).FirstOrDefault();
                linq.Id = pageCopy.Id;
                linq.Sex = pageCopy.Sex;
                linq.BirthDay = pageCopy.BirthDay;
                linq.City = pageCopy.City;
                linq.Country = pageCopy.Country;
                linq.AboutMyself = pageCopy.AboutMyself;
                ew.Close();
                db.SaveChanges();
            }
            //myPageViewModel = new MyPageViewModel();
            ApplyChangesToPage();

        }
        public void EdWnd() ///Окно для выбора картинки
        {
            try
            {
                OpenFileDialog openwnd = new OpenFileDialog
                {
                    Filter = "Image files(*.png)|*.png|Image files(*.jpg)|*.jpg"
                };
                openwnd.ShowDialog();
                img = new Img();
                wayToPic = openwnd.FileName;
            }
            catch
            {
             return;
            }
        }

        private void ApplyChangesToPage()//////применение изменений к странице
        {
            ///////////////////////////////////////////////надо бы это сделать короче, но как?.....
            myPageViewModel.LoadImg(img);
            myPageViewModel.Sex = pageCopy.Sex;
            myPageViewModel.BirthDay = pageCopy.BirthDay;
            myPageViewModel.City = pageCopy.City;
            myPageViewModel.Country = pageCopy.Country;
            myPageViewModel.AboutMyself = pageCopy.AboutMyself;
            if (myPageViewModel.Sex == null || myPageViewModel.Sex == "") { myPageViewModel.SexVis = Visibility.Collapsed; }
            else { myPageViewModel.SexVis = Visibility.Visible; }
            if (myPageViewModel.BirthDay == null) { myPageViewModel.DateVis = Visibility.Collapsed; }
            else { myPageViewModel.DateVis = Visibility.Visible; }
            if (myPageViewModel.Country == null || myPageViewModel.Country == "") { myPageViewModel.CountryVis = Visibility.Collapsed; }
            else { myPageViewModel.CountryVis = Visibility.Visible; }
            if (myPageViewModel.City == null || myPageViewModel.City == "") { myPageViewModel.CityVis = Visibility.Collapsed; }
            else { myPageViewModel.CityVis = Visibility.Visible; }
            if (myPageViewModel.AboutMyself == null || myPageViewModel.AboutMyself == "") { myPageViewModel.AboutVis = Visibility.Collapsed; }
            else { myPageViewModel.AboutVis = Visibility.Visible; }
            ///////////////////////////////////////////////////////////////////////////////////////////
        }
        public string Sex //no
        {
            get { return pageCopy.Sex; }
            set
            {
                pageCopy.Sex = value;
                OnPropertyChanged("Sex");
            }
        }
        public DateTime? BirthDay
        {
            get { return pageCopy.BirthDay; }
            set
            {
                pageCopy.BirthDay = value;
                OnPropertyChanged("BirthDay");
            }
        }
        public string Country
        {
            get { return pageCopy.Country; }
            set
            {
                pageCopy.Country = value;
                OnPropertyChanged("Country");
            }
        }
        public string City
        {
            get { return pageCopy.City; }
            set
            {
                pageCopy.City = value;
                OnPropertyChanged("City");
            }
        }
        public string AboutMyself
        {
            get { return pageCopy.AboutMyself; }
            set
            {
                pageCopy.AboutMyself = value;
                OnPropertyChanged("AboutMyself");
            }
        }
    }
}
