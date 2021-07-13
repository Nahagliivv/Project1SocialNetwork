using CourseProjectOOPVer2._0.View;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class CheckCodeViewModel : NavigateViewModel
    {
        string Code { get; set; }
        private string _EnteredCode { get; set; }
        public string EnteredCode { get { return _EnteredCode; } set { _EnteredCode = value; OnPropertyChanged("EnteredCode"); } }
        public CheckCodeViewModel()
        {
            using(var db = new Model.DB.DataBaseContext())
            {
                Code = Logic.SendCodeToEmail.SendEmailWithCode(db.Users.Where(x => x.Id == Model.CurrentUser.CurrentUserID).First().Email);
            }
        }

        private ICommand _GoBack;
        public ICommand GoBack
        {
            get
            {
                if (_GoBack == null)
                {
                    _GoBack = new RelayCommand(() =>
                    {
                        Navigate("View/LoginPage.xaml");
                    });
                }
                return _GoBack;
            }
            set { _GoBack = value; }
        }
        public ICommand Confirm
        {
            get { return new DelegateCommand(() => { _Confirm(); }); }
        }
        void _Confirm()
        {
            if(EnteredCode != Code)
            {
                Status = "Неверный код";
                return;
            }
            if(EnteredCode == Code)
            {
                using(var db = new Model.DB.DataBaseContext())
                {
                    var usr = db.Users.Where(x => x.Id == Model.CurrentUser.CurrentUserID).FirstOrDefault();
                    usr.IsActivate = true;
                    
                    db.SaveChanges();
                }
                App.Current.MainWindow.Hide();
                App.Current.MainWindow = new MasterWindow();
                App.Current.MainWindow.Show();
            }
        }
        private string _Status { get; set; }
        public string Status { get { return _Status; } set { _Status = value; OnPropertyChanged("Status"); } }
    }
  
}
