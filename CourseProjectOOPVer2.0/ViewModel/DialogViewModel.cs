using CourseProjectOOPVer2._0.Model.DB;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Media;

namespace CourseProjectOOPVer2._0.ViewModel
{
    public class DialogViewModel: ViewModelBase
    {
        private Model.User UserToTalk;
        public ObservableCollection<MessageViewModel> Messages { get; set; }
        private Model.Dialog ExistDialog;
        public DialogViewModel(Model.User u)
        {
            Messages = new ObservableCollection<MessageViewModel>();
            UserToTalk = u;
            UserName = u.Firstname + " " + u.Lastname;
            using (DataBaseContext db = new DataBaseContext())
            {
                ImageSource = Logic.SaveAndLoadPicture.LoadImage(db.Imgs.Where(x => x.Id == UserToTalk.Id).FirstOrDefault().Data);
            }
            MessagesRefresh();
        }
        private void MessagesRefresh()
        {
            using (DataBaseContext db = new DataBaseContext())
            {
                Messages.Clear();
                ExistDialog = db.Dialogs.Where(x => x.User1.Id == Model.CurrentUser.CurrentUserID && x.User2.Id == UserToTalk.Id || x.User2.Id == Model.CurrentUser.CurrentUserID && x.User1.Id == UserToTalk.Id).FirstOrDefault();
                if (ExistDialog != null)
                {
                    IQueryable<Model.Message> findMessages = db.Messages.Where(x => x.DialogId == ExistDialog.Id && x.UserId == Model.CurrentUser.CurrentUserID || x.DialogId == ExistDialog.Id && x.UserId == UserToTalk.Id);

                    foreach (Model.Message x in findMessages)
                    {
                        Messages.Add(new MessageViewModel(x, Messages));
                    }
                }
            }
        }
        private string _SendedMessage { get; set; }
        public string SendedMessage { get { return _SendedMessage; } set { _SendedMessage = value;OnPropertyChanged("SendedMessage"); } }
        public string UserName { get; set; } 
        public ImageSource ImageSource { get; set; }
        public ICommand SendMessage
        {
            get
            {
                return new DelegateCommand(() =>
                {
                    { Send(); }
                });
            }
        }
        private ICommand _Refresh { get; set; }
        public ICommand Refresh { get { return new DelegateCommand(() => { MessagesRefresh(); }); } }
        void Send()
        {
            if(SendedMessage =="" || SendedMessage == null)
            {
                return;
            }
                if(ExistDialog == null)
                {
                using (var db = new DataBaseContext())
                {
                    var dialog = new Model.Dialog() { User1 = db.Users.Where(x => x.Id == Model.CurrentUser.CurrentUserID).First(), User2 = db.Users.Where(x => x.Id == UserToTalk.Id).First(), DateSendLastMessage = DateTime.Now };
                    ExistDialog = dialog;
                    db.Dialogs.Add(dialog);
                    var Message = new Model.Message() { Username = Model.CurrentUser.Current.Firstname + " " + Model.CurrentUser.Current.Lastname, DialogId = dialog.Id, SendDate = DateTime.Now, UserId = Model.CurrentUser.CurrentUserID, Text = SendedMessage };
                    db.Messages.Add(Message);
                    db.SaveChanges();
                    Messages.Add(new MessageViewModel(Message, Messages));
                    SendedMessage = "";
                    return;
                }
                }
                if (ExistDialog != null)
                {
                using (var db = new DataBaseContext())
                {
                    //if(db.Messages.Count(x=>x.Id == ExistDialog.Id) == 0) { ExistDialog = null; Send(); return; }
                    try
                    {
                        var Message = new Model.Message() { Username = Model.CurrentUser.Current.Firstname + " " + Model.CurrentUser.Current.Lastname, DialogId = ExistDialog.Id, SendDate = DateTime.Now, UserId = Model.CurrentUser.CurrentUserID, Text = SendedMessage };
                        db.Messages.Add(Message);
                        db.Dialogs.Attach(ExistDialog);
                        ExistDialog.DateSendLastMessage = Message.SendDate;
                        db.SaveChanges();
                        Messages.Add(new MessageViewModel(Message, Messages));
                        SendedMessage = "";
                        return;
                    }
                    catch
                    {
                        ExistDialog = null;
                        return;
                    }
                }
            }
        }
    }
}
