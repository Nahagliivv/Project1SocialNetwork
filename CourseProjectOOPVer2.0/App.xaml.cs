using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using CourseProjectOOPVer2._0.View;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CourseProjectOOPVer2._0
{
    public partial class App : Application
    {
        private void OnStartup(object sender, StartupEventArgs e)
        {
            //Logic.SendCodeToEmail.SendEmailWithCode("");
            
            long id;
            string password;
            try
            {
            string[] lines = File.ReadAllLines(@"SavedUser/User.txt");
            lines[0] = lines[0].Replace(Environment.NewLine, " "); //удаление /n из айди
            id = Convert.ToInt64(lines[0]);
            password = lines[1];
            using(DataBaseContext db = new DataBaseContext())
            {
              var searchuser = db.Users.Where(x => x.Id == id && x.Password == password).FirstOrDefault();
              if(searchuser!= null && searchuser.IsActivate)
              {
                CurrentUser.CurrentUserID = id;
                CurrentUser.Current = searchuser;
                Current.MainWindow = new MasterWindow();
                Current.MainWindow.Show();
              }
               else { Current.MainWindow = new MainWindow();
                      Current.MainWindow.Show();}
            }
            }
            catch
            {
                Current.MainWindow = new MainWindow();
                Current.MainWindow.Show();
            }
        }
    }
}
