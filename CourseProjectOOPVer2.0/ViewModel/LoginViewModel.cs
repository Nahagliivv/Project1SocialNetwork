using CourseProjectOOPVer2._0.Model;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;
using CourseProjectOOPVer2._0.Model.DB;
using CourseProjectOOPVer2._0.View;
using System.Windows;
using System.IO;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class LoginViewModel : NavigateViewModel
    {
        User u;
        string password;
        string email;
        string status;
        public bool SaveUser { get; set; } = false;
        public LoginViewModel()
        {
        }
        public string Password
        {
            get { return password; }
            set
            {
                password = value;
                OnPropertyChanged("Password");
            }
        }
        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
                OnPropertyChanged("Status");
            }
        }
        public ICommand Login
        {
            get
            {
                return new DelegateCommand<object>((x) =>
                {
                    if (x != null) { RLandP(x); }
                });
            }
        }
        private void RLandP(object Pass)
        {
            var a = Pass as PasswordBox;
            Password = a.Password;
            int linq = 0;
            using (DataBaseContext db = new DataBaseContext())
            {
                linq = db.Users.Count(q => q.Email == Email);
                if (linq == 0)
                {
                    Status = "Зарегистрированного пользователя с таким Email нет";
                    return;
                }
            }
            using(DataBaseContext db = new DataBaseContext())
            {
                var lin = db.Users.Where(q => q.Email == Email).FirstOrDefault();
                u = lin;
            }
            if (HashPassword.VerifyHashedPassword(u.Password, Password))
            {
               CurrentUser.CurrentUserID = u.Id; //////////не трогать!!!
               CurrentUser.Current = u;////это тоже!!
                if(u.IsActivate == false)
                {
                    CheckCode.Execute(_CheckCode);
                    return;
                }
                try
                {
                    if (SaveUser)
                    {
                        using (StreamWriter writer = new StreamWriter(@"SavedUser/User.txt", false, Encoding.Default))
                        {
                            writer.WriteLine(u.Id);
                            writer.WriteLine(u.Password);
                        }
                    }
                }
                catch { MessageBox.Show("Путь SavedUser/User.txt не найдёт, пользоватеь не будет сохранён"); }
               App.Current.MainWindow.Hide();
               App.Current.MainWindow = new MasterWindow();
               App.Current.MainWindow.Show();
            }
            else
            {
                Status = "Неверный пароль";
                return;
            }
        }
        private ICommand _CheckCode;
        public ICommand CheckCode
        {
            get
            {
               
               _CheckCode = new RelayCommand(() =>
               {
               Navigate("View/CheckCode.xaml");
                });
                
                return _CheckCode;
            }
            set { _CheckCode = value; }
        }

        private ICommand _pageReg; //переход на другую стр

        public ICommand Reg
        {
            get
            {
                if (_pageReg == null)
                {
                    _pageReg = new RelayCommand(() =>
                    {
                        Navigate("View/RegPage.xaml");
                    });
                }
                return _pageReg;
            }
            set { _pageReg = value; }
        }
    }
}
