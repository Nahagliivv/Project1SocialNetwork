using CourseProjectOOPVer2._0.Interfaces;
using CourseProjectOOPVer2._0.Model;
using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class MessageHistoryViewModel: ViewModelBase, IMessageHistoryRealization
    {
        private User interlocutor;
        public ImageSource ImageSource { get; set; }
        public string UserName { get; set; }
        public MessageHistoryViewModel(User u)
        {
            interlocutor = u;
            UserName = interlocutor.Firstname + " " + interlocutor.Lastname;
            using(var db = new DataBaseContext())
            {
                ImageSource = Logic.SaveAndLoadPicture.LoadImage(db.Imgs.Where(x => x.Id == interlocutor.Id).FirstOrDefault().Data);
            }
        }
        public ICommand OpenDialog
        {
            get
            {
                return new DelegateCommand(() => { Opend(); });
            }
        }
        void Opend()
        {
            Model.CurrentUser.MasterRef.SlowOpacity(new View.DialogPage(interlocutor));
        }
    }
}
